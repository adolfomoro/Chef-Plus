using ChefPlus.core;
using ChefPlus.data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chef_Plus
{
    public partial class frm_mesas_pedido : XtraForm
    {

        public enum TipoPedido
        {
            Comanda,
            Balcao
        }

        string id_pedido;
        string comanda;
        string abertura;

        string id_cliente;


        public frm_mesas_pedido(string _id, TipoPedido _tipo, string _comanda = null)
        {
            InitializeComponent();

            id_pedido = string.Empty;
            comanda = string.Empty;
            abertura = string.Empty;

            id_cliente = string.Empty;

            ExeSql adapter_categorias = new ExeSql("SELECT * FROM usuarios ORDER BY id ASC");
            lookUpEdit1.Properties.DisplayMember = "nome";
            lookUpEdit1.Properties.ValueMember = "id";
            lookUpEdit1.Properties.DataSource = adapter_categorias.DataSet().Tables[0];

            if (_tipo == TipoPedido.Comanda && _id == null && _comanda != "")
            {
                ExeSql exist_comanda = new ExeSql("select id from pedidos where codigo=@codigo AND (date_delete IS NULL or date_delete = '')");
                exist_comanda.AddParams("@codigo", _comanda, DbType.Int32);

                if (exist_comanda.ExecuteScalarString() == null || exist_comanda.ExecuteScalarString() == "")
                {
                    String query = "INSERT INTO pedidos (id_usuario, date_abertura, codigo, conta_solicitada, id_cliente) VALUES";
                    query += "(@id_usuario, @date_abertura, @codigo,0,0) RETURNING id";

                    var date_abertura = DateHelper.GetDateNow(DateType.Type1);

                    ExeSql cmd_cad = new ExeSql(query);
                    cmd_cad.AddParams("@id_usuario", UserLogin.IdUserGet(), DbType.Int32);
                    cmd_cad.AddParams("@date_abertura", date_abertura);
                    cmd_cad.AddParams("@codigo", _comanda, DbType.Int32);
                    id_pedido = cmd_cad.ExecuteScalarString();
                }
                else
                {
                    id_pedido = exist_comanda.ExecuteScalarString();
                }
            }
            else if (_tipo == TipoPedido.Balcao && _id == null && _comanda == "-1")
            {

                String query = "INSERT INTO pedidos (id_usuario, date_abertura, codigo, conta_solicitada, id_cliente) VALUES";
                query += "(@id_usuario, @date_abertura, @codigo,0,0) RETURNING id";

                var date_abertura = DateHelper.GetDateNow(DateType.Type1);

                ExeSql cmd_cad = new ExeSql(query);
                cmd_cad.AddParams("@id_usuario", UserLogin.IdUserGet(), DbType.Int32);
                cmd_cad.AddParams("@date_abertura", date_abertura);
                cmd_cad.AddParams("@codigo", _comanda, DbType.Int32);
                id_pedido = cmd_cad.ExecuteScalarString();
                //(!) verificar, ao abrir um pedido no balcao, ele define um cliente, (isso nao pode acontecer)
            }
            else
            {
                id_pedido = _id;
            }

        }

        private void treeList1_GetStateImage(object sender, GetStateImageEventArgs e)
        {
            if (e.Node.ParentNode == null)
            {
                e.NodeImageIndex = 0;
            }
            else
            {
                if (e.Node.GetValue("is_part").ToString() == "1")
                {
                    e.NodeImageIndex = 2;
                }
                else
                {
                    e.NodeImageIndex = 1;
                }
                
            }
        }

        void carregarProdutos()
        {
            ExeSql sql = new ExeSql("SELECT id, id_pai, (case when (select id from produtos_personalizados where id=_pedidos_produtos.id_produto) = _pedidos_produtos.id_produto then 1 else 0 end) is_part, nome_produto as descricao, moneyf(quantidade,3) as qt, moneyf(valor_unidade,2) as valor_unidade, moneyf((quantidade * valor_unidade),2) as valor_total  FROM pedidos_produtos as _pedidos_produtos WHERE id_pedido=@id_pedido AND (date_delete IS NULL or date_delete = '') ORDER BY id ASC");
            sql.AddParams("@id_pedido", id_pedido, DbType.Int32);
            treeList1.DataSource = sql.DataTable();
            treeList1.ExpandAll();

            treeList1.BeginSort();
            treeList1.Columns["is_part"].SortOrder = SortOrder.Descending;

            treeList1.EndSort();

            ImageCollection collection = new ImageCollection();
            collection.Images.AddRange(new Image[] { Chef_Plus.Properties.Resources.arrow_right, Chef_Plus.Properties.Resources.complementos, Chef_Plus.Properties.Resources.metade });
            treeList1.StateImageList = collection;
            treeList1.GetStateImage -= treeList1_GetStateImage;
            treeList1.GetStateImage += treeList1_GetStateImage;
        }


        private void frm_mesas_pedido_Load(object sender, EventArgs e)
        {




            ExeSql sql_load = new ExeSql("select *, (select nome from clientes where id=pedidos.id_cliente) as nome_cliente from pedidos as pedidos where id=@id");
            sql_load.AddParams("@id", id_pedido, DbType.Int32);

            NpgsqlDataReader myReader = sql_load.DataReader();
            if (myReader.Read())
            {
                label_pedido.Text = myReader["codigo"].ToString();
                comanda = myReader["codigo"].ToString();

                label_tempo.Text = myReader["date_abertura"].ToString();
                abertura = myReader["date_abertura"].ToString();

                label_id.Text = myReader["id"].ToString();

                textEdit1.Text = myReader["obs"].ToString();

                spinEdit1.Value = Convert.ToInt32(myReader["qt_pessoas"].ToString());

                lookUpEdit1.EditValue = (int)myReader["id_usuario"];

                checkEdit1.Checked = Convert.ToBoolean(Convert.ToInt16(myReader["conta_solicitada"]));

                id_cliente = myReader["id_cliente"].ToString();

                buttonEdit1.Text = myReader["nome_cliente"].ToString();

                if (comanda == "-1")
                {
                    labelControl9.Visible = true;

                    this.Text = "(Balcão) Pedido: " + id_pedido;
                }
                else
                {
                    this.Text = "Pedido: " + id_pedido + " | Comanda/Mesa: " + comanda;

                    labelControl2.Visible = true;
                    label_pedido.Visible = true;
                }
            }
            sql_load.CloseConnection();
            atualiza_permanencia();
            timer1.Enabled = true;
            carregarProdutos();
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked == true)
            {
                panelControl2.Visible = true;

            }
            else
            {
                panelControl2.Visible = false;
            }

            String query_update = "UPDATE pedidos SET conta_solicitada=@conta_solicitada";
            query_update += " WHERE id = @id";
            ExeSql cmd_update = new ExeSql(query_update);

            cmd_update.AddParams("@id", id_pedido, DbType.Int32);
            cmd_update.AddParams("@conta_solicitada", Convert.ToInt16(checkEdit1.Checked), DbType.Int32);
            cmd_update.ExecuteSql();
        }

        private void frm_mesas_pedido_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void frm_mesas_pedido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void spinEdit1_EditValueChanged(object sender, EventArgs e)
        {
            String query_update = "UPDATE pedidos SET qt_pessoas=@qt_pessoas";
            query_update += " WHERE id = @id";
            ExeSql cmd_update = new ExeSql(query_update);

            cmd_update.AddParams("@id", id_pedido, DbType.Int32);
            cmd_update.AddParams("@qt_pessoas", spinEdit1.EditValue.ToString(), DbType.Int32);
            cmd_update.ExecuteSql();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            atualiza_permanencia();
        }
        void atualiza_permanencia()
        {
            TimeSpan teste = Convert.ToDateTime(DateTime.Now.ToString()) - Convert.ToDateTime(DateTime.ParseExact(abertura, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture));
            int horas = teste.Hours;
            int minutos = teste.Minutes;
            string data = horas + "h " + minutos + "min";
            label_tempo.Text = data;
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            String query_update = "UPDATE pedidos SET id_usuario=@id_usuario";
            query_update += " WHERE id = @id";
            ExeSql cmd_update = new ExeSql(query_update);

            cmd_update.AddParams("@id", id_pedido, DbType.Int32);
            cmd_update.AddParams("@id_usuario", lookUpEdit1.EditValue.ToString(), DbType.Int32);
            cmd_update.ExecuteSql();
        }

        private void frm_mesas_pedido_FormClosing(object sender, FormClosingEventArgs e)
        {
            ExeSql exist_comanda = new ExeSql("select count(*) from pedidos_produtos where id_pedido=@id_pedido AND (date_delete IS NULL or date_delete = '')");
            exist_comanda.AddParams("@id_pedido", id_pedido, DbType.Int32);

            if (exist_comanda.ExecuteScalarInt() <= 0 && checkEdit1.Checked == false && textEdit1.Text == "" && (id_cliente == null || id_cliente == "" || id_cliente == "0") && Convert.ToInt32(spinEdit1.EditValue) <= 1)
            {
                ExeSql sql_del = new ExeSql("UPDATE pedidos SET date_delete=@date_delete WHERE id=@id");
                sql_del.AddParams("@id", id_pedido, DbType.Int32);
                sql_del.AddParams("@date_delete", DateHelper.GetDateNow(DateType.Type1));
                sql_del.ExecuteSql();
            }
            else
            {
                String query_update = "UPDATE pedidos SET obs=@obs";
                query_update += " WHERE id = @id";
                ExeSql cmd_update = new ExeSql(query_update);

                cmd_update.AddParams("@id", id_pedido, DbType.Int32);
                cmd_update.AddParams("@obs", textEdit1.Text);
                cmd_update.ExecuteSql();
            }
        }

        private void buttonEdit1_Enter(object sender, EventArgs e)
        {
            consulta_seta_cliente();
        }

        private void buttonEdit1_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            consulta_seta_cliente();
        }

        void consulta_seta_cliente()
        {
            frm_clientes frm = new frm_clientes();
            frm.ShowDialog();
            id_cliente = frm.returnID;

            ExeSql exist_comanda = new ExeSql("select nome from clientes where id=@id AND (date_delete IS NULL or date_delete = '')");
            exist_comanda.AddParams("@id", id_cliente, DbType.Int32);

            buttonEdit1.Text = exist_comanda.ExecuteScalarString();

            ExeSql sql_update = new ExeSql("UPDATE pedidos SET id_cliente=@id_cliente WHERE id=@id");
            sql_update.AddParams("@id", id_pedido, DbType.Int32);
            sql_update.AddParams("@id_cliente", id_cliente, DbType.Int32);
            sql_update.ExecuteSql();

            frm.Dispose();
        }

        private void buttonEdit1_Click(object sender, EventArgs e)
        {
            consulta_seta_cliente();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            ExeSql exist_comanda = new ExeSql("select count(*) from pedidos_produtos where id_pedido=@id_pedido AND (date_delete IS NULL or date_delete = '')");
            exist_comanda.AddParams("@id_pedido", id_pedido, DbType.Int32);

            if (exist_comanda.ExecuteScalarInt() <= 0 && checkEdit1.Checked == false && textEdit1.Text == "" && (id_cliente == null || id_cliente == "" || id_cliente == "0") && Convert.ToInt32(spinEdit1.EditValue) <= 1)
            {
                //(!)Abrir janela de exclusao de pedido
            }
            else
            {
                InfoUser.MessageBoxShow("Não é possível excluir este registro.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void treeList1_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {


        }

        private void treeList1_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)

        { 


        }

        private void treeList1_CustomDrawRow(object sender, CustomDrawRowEventArgs e)
        {

        }

        private void treeList1_CustomDrawNodeImages(object sender, CustomDrawNodeImagesEventArgs e)
        {

        }

        private void frm_mesas_pedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            int i;
            if (int.TryParse(e.KeyChar.ToString(), out i))
            {
                e.Handled = true;
                frm_consulta_produto frm = new frm_consulta_produto(id_pedido, e.KeyChar.ToString());
                frm.ShowDialog();
                frm.Dispose();
                carregarProdutos();
                e.Handled = true;
            }
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            frm_lanca_produtos frm = new frm_lanca_produtos();
            frm.ShowDialog();
            frm.Dispose();
            carregarProdutos();
        }
    }
}
