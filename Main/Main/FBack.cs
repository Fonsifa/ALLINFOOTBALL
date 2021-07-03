using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main
{
    public partial class FBack : Form
    {
       
        //public FLandWidget fLandWidget;
        public FBack()
        {
            InitializeComponent();
            //fLandWidget = new FLandWidget();
        }

        /*
         private void uiButton1_Click(object sender, EventArgs e)
        {
            fLandWidget.Show();
            uiPanel1.Controls.Clear();
            uiPanel1.Controls.Add(fLandWidget);
        }
        /*
private void FBack_Load(object sender, EventArgs e)
{
   fLandWidget.TopLevel = false;
   fLandWidget.FormBorderStyle = FormBorderStyle.None;
   fLandWidget.Dock = DockStyle.Fill;
   fLandWidget.ShowFRegister = this.ShowEditForm;//设置委托
   this.MainPage.Controls.Add(fLandWidget);
   fLandWidget.Show();
}
//显示编辑窗口
public void ShowEditForm(FRegister formEdit)
{
   if (tabControlMain.TabCount > 1)
   {
       tabControlMain.TabPages.RemoveAt(1);
   }
   //新建标签页
   TabPage tabPage = new TabPage() { Text = "编辑订单" };
   tabControlMain.TabPages.Add(tabPage);
   tabControlMain.SelectTab(1);
   //在新标签页中显示编辑窗口
   formEdit.TopLevel = false;
   formEdit.FormBorderStyle = FormBorderStyle.None;
   formEdit.Dock = DockStyle.Fill;
   formEdit.CloseEditFrom = this.CloseEditForm;//设置委托
   tabPage.Controls.Add(formEdit);
   formEdit.Show();
}
public void CloseEditForm(FRegister formEdit)
{
   if (formEdit != null) formEdit.Close();
   if (tabControlMain.TabCount > 1)
   {
       tabControlMain.TabPages.RemoveAt(1);
   }

}
private void uiLabel2_Click(object sender, EventArgs e)
{

}
*/
    }
}
