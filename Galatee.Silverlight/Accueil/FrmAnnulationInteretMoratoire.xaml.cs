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
using Galatee.Silverlight.ServiceAccueil;
using Galatee.Silverlight.ServiceFacturation;
using Galatee.Silverlight.Shared;
using Galatee.Silverlight.Resources.Accueil;
//using Galatee.Silverlight.ServiceEservice;

namespace Galatee.Silverlight.Accueil
{
    public partial class FrmAnnulationInteretMoratoire : ChildWindow
    {
        private bool facturesCharges = false;
        private string centre = string.Empty;
        private string client = string.Empty;
        private string ordre = string.Empty;

        private List<ServiceFacturation.CsLclient> Entetefactures = new List<ServiceFacturation.CsLclient>();


        public FrmAnnulationInteretMoratoire()
        {
            InitializeComponent();
            this.Txt_CodeCentre.MaxLength = SessionObject.Enumere.TailleCentre;
            this.txtClient.MaxLength = SessionObject.Enumere.TailleClient ;
            this.txtOrdre .MaxLength = SessionObject.Enumere.TailleOrdre ;
            prgBar.Visibility = System.Windows.Visibility.Collapsed;
            this.dtg_DetailFacture.IsReadOnly = true;
            ChargerDonneeDuSite();
        }
        List<int> lesCentreCaisse = new List<int>();
        List<Galatee.Silverlight.ServiceAccueil.CsCentre> LstCentrePerimetre = new List<ServiceAccueil.CsCentre>();
        List<Galatee.Silverlight.ServiceAccueil.CsSite> lstSite = new List<ServiceAccueil.CsSite>();
        private void ChargerDonneeDuSite()
        {
            try
            {
                if (SessionObject.LstCentre != null && SessionObject.LstCentre.Count > 0)
                {
                    LstCentrePerimetre = Shared.ClasseMEthodeGenerique.RetourCentreByPerimetre(SessionObject.LstCentre.Where(p => p.CODE != SessionObject.Enumere.Generale).ToList(), UserConnecte.listeProfilUser);
                    lstSite = ClasseMEthodeGenerique.RetourneSiteByCentre(LstCentrePerimetre);
                    foreach (Galatee.Silverlight.ServiceAccueil.CsCentre item in LstCentrePerimetre)
                        lesCentreCaisse.Add(item.PK_ID);

                    if (lstSite.Count == 1)
                    {
                        this.Txt_CodeSite.Text = lstSite.First().CODE;
                        this.Txt_LibelleSite.Text = lstSite.First().LIBELLE;
                        this.Txt_CodeSite.Tag = lstSite.First().PK_ID ;
                        lsiteCentre = LstCentrePerimetre.Where(t => t.CODESITE == lstSite.First().CODE).ToList();
                        this.btn_Site.IsEnabled = false;
                    }
                    if (LstCentrePerimetre.Count == 1)
                    {
                        this.Txt_CodeCentre.Text = LstCentrePerimetre.First().CODE;
                        this.Txt_LibelleCentre.Text = LstCentrePerimetre.First().LIBELLE;
                        this.Txt_CodeCentre.Tag = LstCentrePerimetre.First().PK_ID;
                    }
                    return;
                }
                Galatee.Silverlight.ServiceAccueil.AcceuilServiceClient service = new Galatee.Silverlight.ServiceAccueil.AcceuilServiceClient(Utility.ProtocoleFacturation(), Utility.EndPoint("Accueil"));
                service.ListeDesDonneesDesSiteCompleted += (s, args) =>
                {
                    if (args != null && args.Cancelled)
                        return;
                    SessionObject.LstCentre = args.Result;
                    List<Galatee.Silverlight.ServiceAccueil.CsCentre> LstCentre = Shared.ClasseMEthodeGenerique.RetourCentreByPerimetre(SessionObject.LstCentre.Where(p => p.CODE != SessionObject.Enumere.Generale).ToList(), UserConnecte.listeProfilUser);
                    List<Galatee.Silverlight.ServiceAccueil.CsSite> lstSite = ClasseMEthodeGenerique.RetourneSiteByCentre(LstCentre);
                    foreach (Galatee.Silverlight.ServiceAccueil.CsCentre item in LstCentre)
                        lesCentreCaisse.Add(item.PK_ID);
                };
                service.ListeDesDonneesDesSiteAsync(false);
                service.CloseAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void btn_Site_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lstSite.Count > 0)
                {
                    this.btn_Site.IsEnabled = false;
                    Dictionary<string, string> _LstColonneAffich = new Dictionary<string, string>();
                    _LstColonneAffich.Add("CODE", "SITE");
                    _LstColonneAffich.Add("LIBELLE", "LIBELLE");

                    List<object> obj = Shared.ClasseMEthodeGenerique.RetourneListeObjet(lstSite);
                    MainView.UcListeGenerique ctrl = new MainView.UcListeGenerique(obj, _LstColonneAffich, false, "Lots");
                    ctrl.Closed += new EventHandler(galatee_OkClickedSite);
                    ctrl.Show();
                }
            }
            catch (Exception ex)
            {
                Message.ShowError(ex.Message, "Intérêt moratoire");
            }
        }
        List<ServiceAccueil.CsCentre> lsiteCentre = new List<ServiceAccueil.CsCentre>();
        void galatee_OkClickedSite(object sender, EventArgs e)
        {
            Galatee.Silverlight.MainView.UcListeGenerique ctrs = sender as Galatee.Silverlight.MainView.UcListeGenerique;
            if (ctrs.isOkClick)
            {
                this.btn_Site.IsEnabled = true;
                Galatee.Silverlight.ServiceAccueil.CsSite leSite = (Galatee.Silverlight.ServiceAccueil.CsSite)ctrs.MyObject;
                this.Txt_CodeSite.Text = leSite.CODE;
                this.Txt_CodeSite.Tag = leSite.PK_ID ;
                this.Txt_LibelleSite.Text = leSite.LIBELLE;
                lsiteCentre = LstCentrePerimetre.Where(t => t.CODESITE == leSite.CODE).ToList();
                if (lsiteCentre.Count == 1)
                {
                    this.Txt_CodeCentre.Text = lsiteCentre.First().CODE;
                    this.Txt_LibelleCentre.Text = lsiteCentre.First().LIBELLE;
                    this.Txt_CodeCentre.Tag = lsiteCentre.First().PK_ID;
                }
            }
           this.btn_Site.IsEnabled = true;
        }
        private void btn_Centre_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (LstCentrePerimetre.Count > 0)
                {
                    this.btn_Centre.IsEnabled = false;
                    List<object> obj = Shared.ClasseMEthodeGenerique.RetourneListeObjet(lsiteCentre);
                    Dictionary<string, string> _LstColonneAffich = new Dictionary<string, string>();
                    _LstColonneAffich.Add("CODE", "CENTRE");
                    _LstColonneAffich.Add("LIBELLE", "LIBELLE");
                    MainView.UcListeGenerique ctrl = new MainView.UcListeGenerique(obj, _LstColonneAffich, false , "Liste");
                    ctrl.Closed += new EventHandler(galatee_OkClickedCentre);
                    ctrl.Show();
                }
            }
            catch (Exception ex)
            {
                Message.ShowError(ex.Message, "Intérêt moratoire");
            }
        }
        void galatee_OkClickedCentre(object sender, EventArgs e)
        {
            Galatee.Silverlight.MainView.UcListeGenerique ctrs = sender as Galatee.Silverlight.MainView.UcListeGenerique;
            if (ctrs.isOkClick)
            {
                this.btn_Centre.IsEnabled = true;
                Galatee.Silverlight.ServiceAccueil.CsCentre leCentre = (Galatee.Silverlight.ServiceAccueil.CsCentre)ctrs.MyObject;
                this.Txt_CodeCentre.Text = leCentre.CODE;
                this.Txt_CodeCentre.Tag = leCentre.PK_ID;
                this.Txt_LibelleCentre.Text  = leCentre.LIBELLE ;
            }
            else
                this.btn_Centre.IsEnabled = true;

        }
        private void Txt_CodeSite_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(Txt_CodeSite.Text) && Txt_CodeSite.Text.Length == SessionObject.Enumere.TailleCentre)
                {
                    Galatee.Silverlight.ServiceAccueil.CsSite _LeSiteClient = ClasseMEthodeGenerique.RetourneObjectFromList(lstSite, this.Txt_CodeSite.Text, "CODE");
                    if (!string.IsNullOrEmpty(_LeSiteClient.LIBELLE))
                    {
                        this.Txt_LibelleSite.Text = _LeSiteClient.LIBELLE;
                        this.Txt_CodeSite.Text = _LeSiteClient.CODE;
                        this.Txt_CodeSite.Tag = _LeSiteClient.PK_ID;
                        List<ServiceAccueil.CsCentre> lsiteCentre = LstCentrePerimetre.Where(t => t.FK_IDCODESITE == (int)this.Txt_CodeSite.Tag).ToList();
                        if (lsiteCentre.Count == 1)
                        {
                            this.Txt_CodeCentre.Text = lsiteCentre.First().CODE;
                            this.Txt_LibelleCentre.Text = lsiteCentre.First().LIBELLE;
                            this.Txt_CodeCentre.Tag = lsiteCentre.First().PK_ID;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Message.ShowError(ex.Message, "Intérêt moratoire");

            }
        }
        private void Txt_CodeCentre_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(Txt_CodeCentre.Text) && Txt_CodeCentre.Text.Length == SessionObject.Enumere.TailleCentre)
                {
                    ServiceAccueil.CsCentre _LeCentreClient = ClasseMEthodeGenerique.RetourneObjectFromList(LstCentrePerimetre.Where(t => t.FK_IDCODESITE == (int)this.Txt_CodeSite.Tag).ToList(), this.Txt_CodeCentre.Text, "CODE");
                    if (!string.IsNullOrEmpty(_LeCentreClient.LIBELLE))
                    {
                        this.Txt_CodeCentre.Text = _LeCentreClient.CODE;
                        this.Txt_LibelleCentre.Text = _LeCentreClient.LIBELLE;
                        this.Txt_CodeCentre.Tag = _LeCentreClient.PK_ID;
                    }
                }
            }
            catch (Exception ex)
            {
                Message.ShowError(ex.Message, "Intérêt moratoire");

            }
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (this.cmbFacture.SelectedItem != null)
                {
                    int id = ((ServiceFacturation.CsLclient)this.cmbFacture.SelectedItem).PK_ID;

                    //Shared.ClasseMEthodeGenerique.SetMachineAndPortFromEndPoint(Utility.EndPoint("Facturation"));
                    AcceuilServiceClient service = new AcceuilServiceClient(Utility.ProtocoleFacturation(), Utility.EndPoint("Accueil"));
                    string key = Utility.getKey();
                    service.ValiderAnnulationIMOAsync(id, UserConnecte.matricule);
                    service.ValiderAnnulationIMOCompleted += (er, res) =>
                    {
                        try
                        {
                            if (res.Error != null || res.Cancelled)
                            {
                                //LoadingManager.EndLoading(loaderHandler);
                                throw new Exception("Cannot display report");
                            }
                            if (res.Result)
                            {
                                Message.Show("L'intérêt moratoire a été annulé avec succès.", "Annulation");
                                this.DialogResult = true;
                                return;
                            }
                            else
                                Message.ShowWarning("Echec à l'annulation de l'intérêt moratoire.", "Erreur");

                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        finally
                        {
                        }

                    };

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }



        private void RecherCherFacture()
        {
            try
            {
                if (Txt_CodeCentre.Text.Length == SessionObject.Enumere.TailleCentre &&
                    txtClient.Text.Length == SessionObject.Enumere.TailleClient &&
                    txtOrdre.Text.Length == SessionObject.Enumere.TailleOrdre)
                {

                    if (!facturesCharges)
                        prgBar.Visibility = System.Windows.Visibility.Visible ;


                    centre = Txt_CodeCentre.Text;
                    client = txtClient.Text;
                    ordre = txtOrdre.Text;
                    this.cmbFacture.ItemsSource = null;

                    FacturationServiceClient service = new FacturationServiceClient(Utility.ProtocoleFacturation(), Utility.EndPoint("Facturation"));
                    service.retourneFactureAnnulationInteretMoratoireAsync((int)this.Txt_CodeCentre.Tag, centre, client, ordre);
                    service.retourneFactureAnnulationInteretMoratoireCompleted += (er, res) =>
                    {
                        try
                        {
                            if (res.Error != null || res.Cancelled)
                                Message.Show("Erreur dans le traitement des factures : " + res.Error.InnerException.ToString(), "Erreur");
                            else
                                if (res.Result != null && res.Result.Count != 0)
                                {
                                    if (Entetefactures != res.Result)
                                    {
                                        Entetefactures = res.Result;
                                        Entetefactures.ForEach(t => t.REFEMNDOC = t.NDOC + " " + Shared.ClasseMEthodeGenerique.FormatPeriodeMMAAAA (t.REFEM));

                                        this.cmbFacture.ItemsSource = Entetefactures.OrderBy(u => u.REFEM).ToList();
                                        this.cmbFacture.DisplayMemberPath = "REFEMNDOC";
                                        if (Entetefactures.Count == 1)
                                            this.cmbFacture.SelectedItem  = Entetefactures[0];

                                        prgBar.Visibility = System.Windows.Visibility.Collapsed;
                                        if (Entetefactures != null)
                                            if (Entetefactures.Count > 0)
                                                lblNom.Text = Entetefactures.First().NOM;
                                    }
                                }
                                else
                                    Message.Show("Aucun intérêt moratoire trouvé pour ce client",
                                        "Erreur");
                        }
                        catch (Exception ex)
                        {
                            prgBar.Visibility = System.Windows.Visibility.Collapsed;
                            Message.Show("Erreur inconnue :" + ex.Message, "Erreur inconnue");
                        }
                        finally
                        {
                            prgBar.Visibility = System.Windows.Visibility.Collapsed;
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        private void cmbFacture_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (this.cmbFacture.SelectedItem != null)
                {
                    ServiceFacturation.CsLclient leEntfacSelect = (ServiceFacturation.CsLclient)this.cmbFacture.SelectedItem;
                    cmbFacture.Tag = leEntfacSelect;
                    List<ServiceFacturation.CsLclient> _lstDetail = new List<ServiceFacturation.CsLclient>();
                    _lstDetail.Add(leEntfacSelect);

                    this.dtg_DetailFacture.ItemsSource = null;
                    this.dtg_DetailFacture.ItemsSource = _lstDetail;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void initCtrl()
        {
            this.lblNom.Text = string.Empty;
        }

        private void btn_Rechercher_Click(object sender, RoutedEventArgs e)
        {
            RecherCherFacture();
        }
    }
}

