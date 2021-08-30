using Galatee.Silverlight.Shared;
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

namespace Galatee.Silverlight.Report
{
    public partial class FrmListeInteretMoratoire : ChildWindow
    {
        public FrmListeInteretMoratoire()
        {
            InitializeComponent();
            ChargerDonneeDuSite();
            ChargerCategorie();
            ChargerRegroupement();
            prgBar.Visibility = System.Windows.Visibility.Collapsed;
        }
        string leEtatExecuter = string.Empty;

        List<ServiceAccueil.CParametre> ListeRegroupement;
        List<ServiceAccueil.CParametre> ListeCategorie;
        List<ServiceAccueil.CParametre> _LesCentreSelect;

        public FrmListeInteretMoratoire(string typeEtat)
        {
            InitializeComponent();
            ChargerDonneeDuSite();
            ChargerCategorie();
            ChargerRegroupement();
            leEtatExecuter = typeEtat;
            prgBar.Visibility = System.Windows.Visibility.Collapsed;
        }





        private void ChargerRegroupement()
        {
            try
            {
                if (SessionObject.LstCodeRegroupement == null || SessionObject.LstCodeRegroupement.Count == 0)
                {
                    Galatee.Silverlight.ServiceAccueil.AcceuilServiceClient service = new Galatee.Silverlight.ServiceAccueil.AcceuilServiceClient(Utility.ProtocoleFacturation(), Utility.EndPoint("Accueil"));
                    service.RetourneCodeRegroupementCompleted += (s, args) =>
                    {
                        if (args != null && args.Cancelled)
                            return;
                        SessionObject.LstCodeRegroupement = args.Result;
                    };
                    service.RetourneCodeRegroupementAsync();
                    service.CloseAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            List<int> lstCentre = new List<int>();
            List<int> lstRegroupement = new List<int>();
            List<int>  lstCategorie = new List<int>();

            if (this.cmbCentre.ItemsSource != null)
            {
                foreach (ServiceAccueil.CParametre st in this._LesCentreSelect)
                {
                    lstCentre.Add(st.PK_ID);
                }
            }

            else
            {
                Message.ShowWarning("Veuillez sélectionner les centres", "Report");
                return;
            }


            if (this.cmbCategorie.ItemsSource != null)
            {
                foreach (ServiceAccueil.CParametre st in this.ListeCategorie)
                {
                    lstCategorie.Add(st.PK_ID);
                }
            }
            else
            {
                Message.ShowWarning("Veuillez sélectionner les catégorie", "Report");
                return;
            }


            if (this.cmbRegroupement.ItemsSource != null)
            {
                foreach (ServiceAccueil.CParametre st in this.ListeRegroupement)
                {
                    lstRegroupement.Add(st.PK_ID);
                }
            }
            //else
            //{
            //    Message.ShowWarning("Veuillez sélectionner les regroupements", "Report");
            //    return;
            //}




            string debut = ClasseMEthodeGenerique.FormatPeriodeMMAAAA(this.txtPeriodeDebut.Text);
            string fin = ClasseMEthodeGenerique.FormatPeriodeMMAAAA(this.txtPeriodeDebut.Text);

            prgBar.Visibility = System.Windows.Visibility.Visible ;

            ListeDesInteretsMoratoire(lstCentre, lstCategorie, lstRegroupement, debut, fin, leEtatExecuter);
            
        }

        private void ListeDesInteretsMoratoire(List<int> lstCentre, List<int> lstCategorie, List<int> lstRegroupement, string debut, string fin, string leEtatExecuter)
        {
            Galatee.Silverlight.ServiceReport.ReportServiceClient service1 = new Galatee.Silverlight.ServiceReport.ReportServiceClient(Utility.ProtocoleFacturation(), Utility.EndPoint("Report"));
            service1.RetourneListeDesInteretsMoratoireCompleted += (sr, res) =>
            {
                prgBar.Visibility = System.Windows.Visibility.Collapsed;

                if (res != null && res.Cancelled)
                    return;

                if (res.Result != null && res.Result.Count != 0)
                {
                    Dictionary<string, string> param = new Dictionary<string, string>();
                    param.Add("pParametre", "PERIODE DU " + this.txtPeriodeDebut.Text + " AU " + this.txtPeriodeFin.Text);

                    if (leEtatExecuter == SessionObject.ListeInteretsMoratoireDus)
                        Utility.ActionExportation<ServicePrintings.CsLclient, ServiceReport.CsLclient>(res.Result, param, string.Empty, SessionObject.CheminImpression, "ListeInteretMoratoireDu", "Report", true, "pdf");
                    if (leEtatExecuter == SessionObject.ListeInteretsMoratoirePayés)
                        Utility.ActionExportation<ServicePrintings.CsLclient, ServiceReport.CsLclient>(res.Result, param, string.Empty, SessionObject.CheminImpression, "ListeInteretMoratoirePaye", "Report", true, "pdf");
                    if (leEtatExecuter == SessionObject.ListeInteretsMoratoireAnnulés)
                        Utility.ActionExportation<ServicePrintings.CsLclient, ServiceReport.CsLclient>(res.Result, param, string.Empty, SessionObject.CheminImpression, "ListeInteretMoratoireAnnule", "Report", true, "pdf");

                }
                else
                {
                    Message.ShowInformation("Aucune information trouvée", "Report");
                    return;
                }
            };
            service1.RetourneListeDesInteretsMoratoireAsync(lstCentre, lstCategorie, lstRegroupement, debut, fin, leEtatExecuter);
            service1.CloseAsync();
        }









        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        List<int> lesCentreCaisse = new List<int>();
        List<Galatee.Silverlight.ServiceAccueil.CsCentre> LstCentrePerimetre = new List<ServiceAccueil.CsCentre>();
        List<Galatee.Silverlight.ServiceAccueil.CsSite> lstSite = new List<Galatee.Silverlight.ServiceAccueil.CsSite>();
        Galatee.Silverlight.ServiceAccueil.CsSite lSiteSelect = new Galatee.Silverlight.ServiceAccueil.CsSite();
        List<Galatee.Silverlight.ServiceAccueil.CsProduit> lProduitSelect = new List<Galatee.Silverlight.ServiceAccueil.CsProduit>();
        List<Galatee.Silverlight.ServiceAccueil.CsTournee> lstTourneCentre = new List<Galatee.Silverlight.ServiceAccueil.CsTournee>();

        private void ChargerCategorie()
        {
            try
            {
                if (SessionObject.LstCategorie.Count != 0)
                    return;
                Galatee.Silverlight.ServiceAccueil.AcceuilServiceClient service = new Galatee.Silverlight.ServiceAccueil.AcceuilServiceClient(Utility.ProtocoleFacturation(), Utility.EndPoint("Accueil"));
                service.RetourneCategorieCompleted += (s, args) =>
                {
                    if (args != null && args.Cancelled)
                        return;
                    SessionObject.LstCategorie = args.Result;
                };
                service.RetourneCategorieAsync();
                service.CloseAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ChargerDonneeDuSite()
        {
            try
            {
                if (SessionObject.LstCentre != null && SessionObject.LstCentre.Count > 0)
                {
                    LstCentrePerimetre = Shared.ClasseMEthodeGenerique.RetourCentreByPerimetre(SessionObject.LstCentre.Where(p => p.LIBELLE != SessionObject.Enumere.Generale).ToList(), UserConnecte.listeProfilUser);
                    lstSite = Galatee.Silverlight.Shared.ClasseMEthodeGenerique.RetourneSiteByCentre(LstCentrePerimetre);
                    foreach (Galatee.Silverlight.ServiceAccueil.CsCentre item in LstCentrePerimetre)
                        lesCentreCaisse.Add(item.PK_ID);



                    if (lstSite != null && lstSite.Count != 0)
                    {
                        if (lstSite.Count == 1)
                        {
                            this.txtSite.Text = lstSite.First().LIBELLE;
                            this.txtSite.Tag = lstSite.First().PK_ID;

                            lSiteSelect = lstSite.First();
                            List<ServiceAccueil.CsCentre> lsiteCentre = LstCentrePerimetre.Where(t => t.FK_IDCODESITE == (int)this.txtSite.Tag).ToList();
                            if (lsiteCentre.Count == 1)
                            {
                                this.cmbCentre.ItemsSource = lsiteCentre.First().LIBELLE;
                                this.cmbCentre.ItemsSource = lsiteCentre;
                                this.btn_Centre.IsEnabled = true;
                            }
                            else
                            {
                                this.cmbCentre.ItemsSource = string.Empty;
                                this.cmbCentre.ItemsSource = null;
                                this.btn_Centre.IsEnabled = true;
                            }
                        }
                    }
                    if (LstCentrePerimetre.Count == 1)
                    {
                        this.cmbCentre.ItemsSource = LstCentrePerimetre.First().LIBELLE;
                        this.cmbCentre.ItemsSource = LstCentrePerimetre.First().LIBELLE;
                        this.cmbCentre.ItemsSource = LstCentrePerimetre;

                    }

                    return;
                }
                Galatee.Silverlight.ServiceAccueil.AcceuilServiceClient service = new Galatee.Silverlight.ServiceAccueil.AcceuilServiceClient(Utility.ProtocoleFacturation(), Utility.EndPoint("Accueil"));
                service.ListeDesDonneesDesSiteCompleted += (s, args) =>
                {
                    if (args != null && args.Cancelled)
                        return;
                    SessionObject.LstCentre = args.Result;
                    LstCentrePerimetre = Shared.ClasseMEthodeGenerique.RetourCentreByPerimetre(SessionObject.LstCentre.Where(p => p.LIBELLE != SessionObject.Enumere.Generale).ToList(), UserConnecte.listeProfilUser);
                    lstSite = Galatee.Silverlight.Shared.ClasseMEthodeGenerique.RetourneSiteByCentre(LstCentrePerimetre);
                    foreach (Galatee.Silverlight.ServiceAccueil.CsCentre item in LstCentrePerimetre)
                        lesCentreCaisse.Add(item.PK_ID);


                    if (lstSite != null && lstSite.Count != 0)
                    {
                        if (lstSite.Count == 1)
                        {
                            lSiteSelect = lstSite.First();
                            this.cmbCentre.ItemsSource = lstSite.First().LIBELLE;
                        }
                    }
                    if (LstCentrePerimetre != null && LstCentrePerimetre.Count != 0)
                    {

                        if (LstCentrePerimetre.Count == 1)
                        {
                            this.cmbCentre.ItemsSource = LstCentrePerimetre.First().LIBELLE;
                            this.btn_Centre.IsEnabled = false;
                        }
                    }
                };
                service.ListeDesDonneesDesSiteAsync(false);
                service.CloseAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btn_Centre_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (LstCentrePerimetre.Count != 0)
                {
                    List<ServiceAccueil.CParametre> lstParametre = Shared.ClasseMEthodeGenerique.RetourneValueFromClasse<ServiceAccueil.CsCentre>(LstCentrePerimetre.Where(a => a.FK_IDCODESITE == (int)this.txtSite.Tag).ToList());

                    Shared.UcListeParametre ctr = new Galatee.Silverlight.Shared.UcListeParametre(lstParametre, true, "Centre");

                    ctr.Closed += new EventHandler(galatee_OkClickedCentre);
                    ctr.Show();
                }
            }
            catch (Exception ex)
            {
                Message.ShowError(ex, "Erreur");
            }
        }
        private void galatee_OkClickedCentre(object sender, EventArgs e)
        {
            try
            {

                Shared.UcListeParametre ctrs = sender as Shared.UcListeParametre;
                if (ctrs.isOkClick)
                {
                    _LesCentreSelect = ctrs.MyObjectList as List<ServiceAccueil.CParametre>;
                    List<string> lstCentre = _LesCentreSelect.Select(t => t.LIBELLE).ToList();
                    //this.Txt_LibelleCentre.Text = string.Empty;
                    //foreach (string item in lstCentre)
                    //    this.Txt_LibelleCentre.Text = item + " " + this.Txt_LibelleCentre.Text;

                    //this.Txt_LibelleCentre.Tag = _LesCentreSelect.Select(t => t.PK_ID).ToList();
                    cmbCentre.ItemsSource = lstCentre;
                }
            }
            catch (Exception ex)
            {
                Message.ShowError(ex, "Erreur");
            }
        }

        private void btn_Site_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lstSite.Count > 0)
                {
                    this.btn_Site.IsEnabled = false;
                    List<object> _Listgen = Galatee.Silverlight.Shared.ClasseMEthodeGenerique.RetourneListeObjet(lstSite);
                    Galatee.Silverlight.MainView.UcListeGenerique ctr = new Galatee.Silverlight.MainView.UcListeGenerique(_Listgen, "CODE", "LIBELLE", "Liste");

                    ctr.Closed += new EventHandler(galatee_OkClickedSite);
                    ctr.Show();
                }
            }
            catch (Exception ex)
            {
                Message.ShowError(ex.Message, "Report");
            }

        }
        void galatee_OkClickedSite(object sender, EventArgs e)
        {
            Galatee.Silverlight.MainView.UcListeGenerique ctrs = sender as Galatee.Silverlight.MainView.UcListeGenerique;
            if (ctrs.isOkClick)
            {
                Galatee.Silverlight.ServiceAccueil.CsSite leSite = (Galatee.Silverlight.ServiceAccueil.CsSite)ctrs.MyObject;
                this.txtSite.Text = leSite.LIBELLE;
                this.txtSite.Tag = leSite.PK_ID;

                lSiteSelect = leSite;
                List<ServiceAccueil.CsCentre> lsiteCentre = LstCentrePerimetre.Where(t => t.FK_IDCODESITE == (int)this.txtSite.Tag).ToList();
                if (lsiteCentre.Count == 1)
                {
                    this.cmbCentre.ItemsSource = lsiteCentre.First().LIBELLE;
                    this.cmbCentre.ItemsSource = lsiteCentre;
                    this.btn_Centre.IsEnabled = true;
                }
                else
                {
                    this.cmbCentre.ItemsSource = string.Empty;
                    this.cmbCentre.ItemsSource = null;
                    this.btn_Centre.IsEnabled = true;
                }
            }
            this.btn_Site.IsEnabled = true;

        }


        private void btn_Categorie_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<ServiceAccueil.CParametre> lstParametre = Shared.ClasseMEthodeGenerique.RetourneValueFromClasse<ServiceAccueil.CsCategorieClient>(SessionObject.LstCategorie);
                Shared.UcListeParametre ctr = new Galatee.Silverlight.Shared.UcListeParametre(lstParametre, true, "Liste catégories");

                ctr.Closed += new EventHandler(categorie_OkClicked);
                ctr.Show();
            }
            catch (Exception ex)
            {
                Message.ShowError(ex, "Erreur");
            }

        }
        private void categorie_OkClicked(object sender, EventArgs e)
        {
            try
            {

                Shared.UcListeParametre ctrs = sender as Shared.UcListeParametre;
                if (ctrs.isOkClick)
                {
                    ListeCategorie = ctrs.MyObjectList as List<ServiceAccueil.CParametre>;
                    List<string> lstCategorie = ListeCategorie.Select(t => t.LIBELLE).ToList();
                    cmbCategorie.ItemsSource = lstCategorie;
                }
            }
            catch (Exception ex)
            {
                Message.ShowError(ex, "Erreur");
            }
        }


        private void btn_Regroupement_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<ServiceAccueil.CParametre> lstParametre = Shared.ClasseMEthodeGenerique.RetourneValueFromClasse<ServiceAccueil.CsRegCli>(SessionObject.LstCodeRegroupement);
                Shared.UcListeParametre ctr = new Galatee.Silverlight.Shared.UcListeParametre(lstParametre, true, "Liste regroupements");

                ctr.Closed += new EventHandler(regroupement_OkClicked);
                ctr.Show();
            }
            catch (Exception ex)
            {
                Message.ShowError(ex, "Erreur");
            }

        }
        private void regroupement_OkClicked(object sender, EventArgs e)
        {
            try
            {

                Shared.UcListeParametre ctrs = sender as Shared.UcListeParametre;
                if (ctrs.isOkClick)
                {
                    ListeRegroupement = ctrs.MyObjectList as List<ServiceAccueil.CParametre>;
                    List<string> lstRegroupement = ListeRegroupement.Select(t => t.LIBELLE).ToList();
                    cmbRegroupement.ItemsSource = lstRegroupement;
                }
            }
            catch (Exception ex)
            {
                Message.ShowError(ex, "Erreur");
            }
        }



    }
}

