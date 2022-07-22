using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            String UltimaEtiqueta = "";
            InitializeComponent();
            XmlTextReader xmlTextReader = new XmlTextReader("archivoBiblioteca.xml");
            String Ultimocambio = "";

            while (xmlTextReader.Read())
            {
                if (xmlTextReader.NodeType ==XmlNodeType.Element)

                {
                    Ultimocambio += (new String(' ', xmlTextReader.Depth * 3) + "<" + xmlTextReader.Name + ">");
                    UltimaEtiqueta = xmlTextReader.Name;
                    continue;
                }
                if (xmlTextReader.NodeType == XmlNodeType.Text)

                {
                    Ultimocambio += xmlTextReader.ReadContentAsString() + "</" + UltimaEtiqueta + ">";

                }
                else
                    Ultimocambio += "\r";

            }
            xmlTextReader.Close();
        }

            //Variables de Programa
            List<Libro> Biblioteca = new List<Libro>();

        private void bntGuardarLibro_Click(object sender, EventArgs e)
        {
            string sexo = "";
            if (rbtnHombre.Checked) {
                sexo = "Hombre";
            }
            else {
                sexo = "Mujer";
            }

            Persona autor = new Persona(txtId.Text, txtNombre.Text, txtNacionalidad.Text, mtcFechaNacimiento.SelectionStart, sexo );
            
            Libro libroRegistrado = new Libro();
            libroRegistrado.codigo = int.Parse(txtCodigo.Text);
            libroRegistrado.autor = autor;
            libroRegistrado.añoPublicado = int.Parse(txtAnno.Text);
            libroRegistrado.nombre = txtTitulo.Text;
            libroRegistrado.resumen = txtResumen.Text;

            Biblioteca.Add(libroRegistrado);
            limpiaCampos();
        }

        private void limpiaCampos() {
            txtId.Text = "";
            txtNombre.Text = "";
            txtNacionalidad.Text = "";
            txtCodigo.Text = "";
            txtAnno.Text = "";
            txtTitulo.Text = "";
            txtResumen.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Raiz del documento
            XmlDocument documento = new XmlDocument();
            XmlElement raiz = documento.CreateElement("Biblioteca");
            documento.AppendChild(raiz);

            for (int i = 0; i < Biblioteca.Count; i++) {
                //Agrega el libro
                XmlElement libro = documento.CreateElement("libro");
                raiz.AppendChild(libro);
                //Agrega los datos del libro
                XmlElement codigo = documento.CreateElement("codigo");
                codigo.AppendChild(documento.CreateTextNode(Biblioteca.ElementAt(i).codigo.ToString()));
                libro.AppendChild(codigo);

                XmlElement nombre = documento.CreateElement("nombre");
                nombre.AppendChild(documento.CreateTextNode(Biblioteca.ElementAt(i).nombre));
                libro.AppendChild(nombre);

                XmlElement anno = documento.CreateElement("añoPublicacion");
                anno.AppendChild(documento.CreateTextNode(Biblioteca.ElementAt(i).añoPublicado.ToString()));
                libro.AppendChild(anno);

                XmlElement resumen = documento.CreateElement("resumen");
                resumen.AppendChild(documento.CreateTextNode(Biblioteca.ElementAt(i).resumen));
                libro.AppendChild(resumen);



                XmlElement idAutor = documento.CreateElement("idAutor");
                idAutor.AppendChild(documento.CreateTextNode(Biblioteca.ElementAt(i).autor.id.ToString()));
                libro.AppendChild(idAutor);

                XmlElement nombreAutor = documento.CreateElement("nombreAutor");
                nombreAutor.AppendChild(documento.CreateTextNode(Biblioteca.ElementAt(i).autor.nombre));
                libro.AppendChild(nombreAutor);

                XmlElement nacionalidadAutor = documento.CreateElement("nacionalidadAutor");
                nacionalidadAutor.AppendChild(documento.CreateTextNode(Biblioteca.ElementAt(i).autor.nacionalidad));
                libro.AppendChild(nacionalidadAutor);

                XmlElement nacimientoAutor = documento.CreateElement("nacimientoAutor");
                nacimientoAutor.AppendChild(documento.CreateTextNode(Biblioteca.ElementAt(i).autor.fechaNacimiento.ToString()));
                libro.AppendChild(nacimientoAutor);

                XmlElement sexoAutor = documento.CreateElement("sexoAutor");
                sexoAutor.AppendChild(documento.CreateTextNode(Biblioteca.ElementAt(i).autor.sexo));
                libro.AppendChild(sexoAutor);

                

                
                
            }
            documento.Save("archivoBiblioteca.xml");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
