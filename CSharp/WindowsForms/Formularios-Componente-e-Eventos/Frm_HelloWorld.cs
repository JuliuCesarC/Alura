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
      // O 'Application.Exit' ira fechar toda a aplicação.
      // Application.Exit();
      // Ao abrir esta formulário através do formulário 'Principal' e clicarmos no botão sair, o comando acima ira fechar todos os formulários, porem seria interessante fechar apenas este formulário. Para resolver isso podemos utilizar o comando abaixo:
      this.Close();
    }

    private void btn_alteraTitulo_Click(object sender, EventArgs e)
    {
      lbl_Titulo.Text = txt_conteudoLabel.Text;
    }
  }
}