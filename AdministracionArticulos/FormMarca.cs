﻿using Models;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdministracionArticulos
{
    public partial class FormMarca : Form
    {
        private Marca marca = null;

        public FormMarca()
        {
            InitializeComponent();
        }
        public FormMarca(Marca marca)
        {
            InitializeComponent();
            this.marca = marca;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            MarcaServices service = new MarcaServices();

            try
            {
                if (marca == null)
                {
                    marca = new Marca();
                }

                marca.Descripcion = TxtBoxDescripcion.Text;

                if (marca.Id != 0)
                {
                    service.modify(marca);
                    MessageBox.Show("Marca modificado exitosamente");
                }
                else
                {
                    service.add(marca);
                    MessageBox.Show("Marca agregado exitosamente");
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void FormMarca_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void cargar()
        {
            ArticuloServices articuloService = new ArticuloServices();
            MarcaServices marcaServices = new MarcaServices();
            CategoriaServices categoriaServices = new CategoriaServices();

            try
            {
                if (marca != null)
                {
                    BtnAgregar.Text = "Modificar";
                    TxtBoxDescripcion.Text = marca.Descripcion;  
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
