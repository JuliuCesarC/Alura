namespace Formularios_Componente_e_Eventos
{
  public partial class Frm_HelloWorld: Form
  {
    public Frm_HelloWorld()
    {
      InitializeComponent();
    }

    private void btn_sair_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void btn_alteraTitulo_Click(object sender, EventArgs e)
    {
      lbl_Titulo.Text = txt_conteudoLabel.Text;
    }
  }
}