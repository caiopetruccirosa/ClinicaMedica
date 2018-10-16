﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoClinica.DB.DBO;

namespace ProjetoClinica
{
    public partial class Medico : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            object usuario = Session["Usuario"];

            if (Session.IsNewSession || usuario == null || usuario.GetType() != typeof(MedicoDBO))
            {
                Response.Redirect("/index.aspx");
            } else
            {
                MedicoDBO m = (MedicoDBO) Session["Usuario"];

                if (m.Imagem == null)
                    ImgPerfil.ImageUrl = "/img/default_profile_picture.png";

                LblNome.Text = m.Nome_Completo.Split(' ')[0];
            }
        }

        protected void LbSair_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("/index.aspx");
        }
    }
}