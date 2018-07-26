using System;
using System.Windows.Forms;
using System.Xml;

namespace EstudoXML
{
    public partial class frmAgenda : Form
    {
        public frmAgenda()
        {
            InitializeComponent();
        }

        private void frmAgenda_Load(object sender, EventArgs e)
        {
            CriarContato();
            lblTitulo.Text = CarregarTitulo();
            CarregarContatos();
            
        }

        private string CarregarTitulo()
        {
            XmlDocument documentoXml = new XmlDocument();
            documentoXml.Load(@"C:\Users\david.araujo\source\repos\TreinaWeb.CSharpIntermediario\EstudoXML\Agenda.xml");
            XmlNode noTitulo = documentoXml.SelectSingleNode("/agenda/titulo");

            return noTitulo.InnerText;
        }

        private void CarregarContatos()
        {
            XmlDocument documentoXml = new XmlDocument();
            documentoXml.Load(@"C:\Users\david.araujo\source\repos\TreinaWeb.CSharpIntermediario\EstudoXML\Agenda.xml");
            XmlNodeList contatos = documentoXml.SelectNodes("/agenda/contatos/contato");
            foreach (XmlNode contato in contatos)
            {
                string representacaoDoContato = "";
                string id = contato.Attributes["id"].Value;
                string nome = contato.Attributes["nome"].Value;
                string idade = contato.Attributes["idade"].Value;
                representacaoDoContato = "Nome: " + nome + ", Idade: " + idade + ", Id: " + id;
                lbxContatos.Items.Add(representacaoDoContato);
            }
        }

        private void CriarContato()
        {
            XmlDocument documentoXml = new XmlDocument();
            documentoXml.Load(@"C:\Users\david.araujo\source\repos\TreinaWeb.CSharpIntermediario\EstudoXML\Agenda.xml");
            XmlAttribute atributoId = documentoXml.CreateAttribute("id");
            atributoId.Value = "5";

            XmlAttribute atributoNome = documentoXml.CreateAttribute("nome");
            atributoNome.Value = "teste novo Elemento";

            XmlAttribute atributoIdade = documentoXml.CreateAttribute("idade");
            atributoIdade.Value = "50";

            XmlNode novoContato = documentoXml.CreateElement("contato");

            novoContato.Attributes.Append(atributoId);
            novoContato.Attributes.Append(atributoNome);
            novoContato.Attributes.Append(atributoIdade);

            XmlNode contatos = documentoXml.SelectSingleNode("/agenda/contatos");
            contatos.AppendChild(novoContato);

            documentoXml.Save(@"C: \Users\david.araujo\source\repos\TreinaWeb.CSharpIntermediario\EstudoXML\Agenda.xml");
        }
    }
}
