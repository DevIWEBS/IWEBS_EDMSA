using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Galatee.Silverlight.ServiceParametrage ;
using Galatee.Silverlight.MainView;
using Galatee.Silverlight.Shared;
using Galatee.Silverlight.Resources.Index;


namespace Galatee.Silverlight.Parametrage
{
    public partial class FrmExemptionCategorieInteret : ChildWindow
    {

        public FrmExemptionCategorieInteret()
        {
            InitializeComponent();
            Translate();
            ChargerParametres();
        }
        List<CsCategorieClient> lesCategories = new List<CsCategorieClient>();

        private void ChargerParametres()
        {
            try
            {
                ServiceParametrage.ParametrageClient service = new ServiceParametrage.ParametrageClient(Utility.ProtocoleFacturation(), Utility.EndPoint("Parametrage"));
                service.GetCategoriesExemptionInteretMoratoireCompleted += (s, args) =>
                {
                    if (args != null && args.Cancelled)
                        return;
                    lesCategories = args.Result;

                    if (lesCategories != null && lesCategories.Count != 0)
                    {
                        this.dataGrid1.ItemsSource = null;
                        this.dataGrid1.ItemsSource = lesCategories.Where(t => !t.IsSelect).ToList();

                        this.dataGrid2.ItemsSource = null;
                        this.dataGrid2.ItemsSource = lesCategories.Where(t => t.IsSelect).ToList();
                    }

                };
                service.GetCategoriesExemptionInteretMoratoireAsync(true);
                service.CloseAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void OKButton_Click(object sender, RoutedEventArgs e)
        {

            List<CsCategorieClient> lstCategorie = (List<CsCategorieClient>)this.dataGrid2.ItemsSource;


            if (lstCategorie == null || lstCategorie.Count() == 0)
                Message.ShowError("Aucune catégorie ne sera exemptée.", "Exemption");
            else
                lstCategorie.ForEach(a => a.USERCREATION = UserConnecte.matricule);

            ValiderAffectation(lstCategorie);

            this.DialogResult = true;
        }



        private void ValiderAffectation(List<CsCategorieClient> lstCategorie)
        {
            try
            {
                ParametrageClient service = new ParametrageClient(Utility.ProtocoleFacturation(), Utility.EndPoint("Parametrage"));
                service.TraiterExemptionInteretMoratoireAsync(lstCategorie);
                service.TraiterExemptionInteretMoratoireCompleted += (s, args) =>
                {
                    try
                    {
                        if (args != null && args.Cancelled)
                        {
                            Message.ShowError("Erreur survenue lors de l'appel du service.", "Erreur");
                            return;
                        }

                        if (!string.IsNullOrEmpty(args.Result))
                            Message.ShowInformation(args.Result, "Affectation");
                        else
                            Message.ShowInformation("Mise à jour validée", "Affectation");
                    }
                    catch (Exception ex)
                    {
                        Message.ShowError(ex, "Erreur");
                    }
                };

                this.dataGrid1.IsEnabled = true;
            }
            catch (Exception ex)
            {
                Message.ShowError(ex, "Erreur");
            }
        }



        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void ChildWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                OKButton.IsEnabled = false;
            }
            catch (Exception ex)
            {
                Message.ShowError(ex, "Erreur");
            }
        }

        private void Translate()
        {
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<CsCategorieClient> ListeSelect = ((List<CsCategorieClient>)this.dataGrid1.ItemsSource).Where(t => t.IsSelect == true).ToList();
            foreach (CsCategorieClient item in ListeSelect)
            {
                item.IsSelect = false;
                dataGrid1.SelectedItems.Add(item);
            }
            Galatee.Silverlight.Shared.CommonMethode.TransfertDataGrid<CsCategorieClient>(dataGrid1, dataGrid2);
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            List<CsCategorieClient> ListeSelect = ((List<CsCategorieClient>)this.dataGrid2.ItemsSource).Where(t => t.IsSelect == true).ToList();
            foreach (CsCategorieClient item in ListeSelect)
            {
                item.IsSelect = false;
                dataGrid2.SelectedItems.Add(item);
            }
            Galatee.Silverlight.Shared.CommonMethode.TransfertDataGrid<CsCategorieClient>(dataGrid2, dataGrid1);
            if (this.dataGrid1.ItemsSource != null)
            {
                List<CsCategorieClient> lstNouvelle = ((List<CsCategorieClient>)this.dataGrid1.ItemsSource).ToList();
                this.dataGrid1.ItemsSource = null;
                this.dataGrid1.ItemsSource = lstNouvelle.OrderBy(o => o.CODE).ToList();
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid2.ItemsSource != null)
            {
                List<CsCategorieClient> lesCasSelect = ((List<CsCategorieClient>)dataGrid2.ItemsSource);
                lesCasSelect.ForEach(t => t.IsSelect = true);
                this.OKButton.IsEnabled = true;

            }
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid1.ItemsSource != null)
            {
                List<CsCategorieClient> lesCasSelect = ((List<CsCategorieClient>)dataGrid1.ItemsSource);
                lesCasSelect.ForEach(t => t.IsSelect = false);

                this.OKButton.IsEnabled = true;
            }
        }

 

 
        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.dataGrid1.SelectedItem != null)
            {
                if (((CsCategorieClient)this.dataGrid1.SelectedItem).IsSelect == false)
                    ((CsCategorieClient)this.dataGrid1.SelectedItem).IsSelect = true;
                else
                    ((CsCategorieClient)this.dataGrid1.SelectedItem).IsSelect = false;
            }
        }

        private void dataGrid2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.dataGrid2.SelectedItem != null)
            {
                if (((CsCategorieClient)this.dataGrid2.SelectedItem).IsSelect == false)
                    ((CsCategorieClient)this.dataGrid2.SelectedItem).IsSelect = true;
                else
                    ((CsCategorieClient)this.dataGrid2.SelectedItem).IsSelect = false;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            List<CsCategorieClient> ListeSelect = ((List<CsCategorieClient>)this.dataGrid2.ItemsSource).ToList();
            foreach (CsCategorieClient item in ListeSelect)
            {
                item.IsSelect = false;
                dataGrid2.SelectedItems.Add(item);
            }
            Galatee.Silverlight.Shared.CommonMethode.TransfertDataGrid<CsCategorieClient>(dataGrid2, dataGrid1);
        }
       
    }
}

