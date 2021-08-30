using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galatee.Entity.Model;
using Galatee.Structure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Data;
using System.IO;
//using Galatee.Tools;

//using Microsoft.Reporting.WebForms;



namespace Galatee.DataAccess
{
    public class DBFRAUDE
    {

     
        private string ConnectionString;
        private string ConnectString = Session.GetSqlConnexionString();
        private SqlCommand cmd = null;
        public SqlCommand Cmd
        {
            get { return cmd; }
            set { cmd = value; }
        }
        private SqlConnection cn = null;

        public DBFRAUDE()
        {
            try
            {
                //ConnectionString = GalateeConfig.ConnectionStrings[Enumere.ConnexionGALADB].ConnectionString;
                //ConnectionString = Session.GetSqlConnexionString();
                //Abo07ConnectionString = Session.GetSqlConnexionStringAbo07();
                ConnectionString = Session.GetSqlConnexionString();

            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<CsUsage> SelectAllUsage()
        {
            try
            {
                List<CsUsage> _lstUsage = new List<CsUsage>();
                DataTable dt = Galatee.Entity.Model.FraudeProcedure.RetourneUsage();
                _lstUsage = Entities.GetEntityListFromQuery<CsUsage>(dt);

                return _lstUsage;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<CsSourceControle> SelectAllSouscontrole()
        {
            cn = new SqlConnection(ConnectionString);

            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandTimeout = 180;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SPX_frd_SOURCECONTROLE";

            DBBase.SetDBNullParametre(cmd.Parameters);
            try
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                return Entities.GetEntityListFromQuery<CsSourceControle >(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(cmd.CommandText + ":" + ex.Message);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close(); // Fermeture de la connection 
                cmd.Dispose();
            }
        }
        public List<CsMoyenDenomciation> SelectAllMoyenDenomciation()
        {
            try
            {
                List<CsMoyenDenomciation> _lstCsMoyenDenomciation = new List<CsMoyenDenomciation>();
                //DataTable dt = Galatee.Entity.Model.FraudeProcedure.RetourneListeMoyendeDenonciation();
                DataTable dt = DBParametrages.SelectAllDonneReference("frd.MOYENDENONCIATION");
                _lstCsMoyenDenomciation = Entities.GetEntityListFromQuery<CsMoyenDenomciation>(dt);

                return _lstCsMoyenDenomciation;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<CsMArqueDisjoncteur> SelectAllMarqueDisjoncteur()
        {
            try
            {
                List<CsMArqueDisjoncteur> _lstCSTypeDisjoncteur = new List<CsMArqueDisjoncteur>();
                //DataTable dt = Galatee.Entity.Model.FraudeProcedure.RetourneListeMarqueDisjoncteur();
                DataTable dt = DBParametrages.SelectAllDonneReference("frd.MARQUEDISJONCTEUR");
                _lstCSTypeDisjoncteur = Entities.GetEntityListFromQuery<CsMArqueDisjoncteur>(dt);

                return _lstCSTypeDisjoncteur;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<CsPhaseCompteur> SelectAllPhaseCompteur()
        {
            try
            {
                List<CsPhaseCompteur> _lstCsPhaseCompteur = new List<CsPhaseCompteur>();
                //DataTable dt = Galatee.Entity.Model.FraudeProcedure.RetourneListePhaseCompteur();
                DataTable dt = DBParametrages.SelectAllDonneReference("PHASECOMPTEUR");
                _lstCsPhaseCompteur = Entities.GetEntityListFromQuery<CsPhaseCompteur>(dt);

                return _lstCsPhaseCompteur;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<CsTypeFraude> SelectAllTypeFraude()
        {
            try
            {
                List<CsTypeFraude> _lstCsOrganeFraude = new List<CsTypeFraude>();
                //DataTable dt = Galatee.Entity.Model.FraudeProcedure.RetourneTypeDeFraude();
                DataTable dt = DBParametrages.SelectAllDonneReference("frd.TYPEFRAUDE");
                _lstCsOrganeFraude = Entities.GetEntityListFromQuery<CsTypeFraude>(dt);

                return _lstCsOrganeFraude;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<CsActionSurCompteur> SelectAllActionSurCompteur()
        {
            try
            {
                cn = new SqlConnection(ConnectionString);

                cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandTimeout = 180;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPX_frd_ACTIONCOMPTEUR";

                DBBase.SetDBNullParametre(cmd.Parameters);
                try
                {
                    if (cn.State == ConnectionState.Closed)
                        cn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    return Entities.GetEntityListFromQuery<CsActionSurCompteur>(dt);
                }
                catch (Exception ex)
                {
                    throw new Exception(cmd.CommandText + ":" + ex.Message);
                }
                finally
                {
                    if (cn.State == ConnectionState.Open)
                        cn.Close(); // Fermeture de la connection 
                    cmd.Dispose();
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<CsOrganeFraude> SelectAllOrganeFraude()
        {
            try
            {
                List<CsOrganeFraude> _sOrganeFraude = new List<CsOrganeFraude>();
                //DataTable dt = Galatee.Entity.Model.FraudeProcedure.RetourneOrganeFraude();
                DataTable dt = DBParametrages.SelectAllDonneReference("frd.ORGANEFRAUDE");

                _sOrganeFraude = Entities.GetEntityListFromQuery<CsOrganeFraude>(dt);

                return _sOrganeFraude;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<CsQualiteExpert> SelectAllQualiteExpert()
        {
            try
            {
                List<CsQualiteExpert> _sOrganeFraude = new List<CsQualiteExpert>();
                //DataTable dt = Galatee.Entity.Model.FraudeProcedure.RetourneQualiteExpert();
                DataTable dt = DBParametrages.SelectAllDonneReference("frd.QUALITEEXPERT");
                _sOrganeFraude = Entities.GetEntityListFromQuery<CsQualiteExpert>(dt);

                return _sOrganeFraude;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public List<CsTypeClient> SelectAllTypeClientFraude()
        {
            try
            {
                List<CsTypeClient> _typeClientFraude = new List<CsTypeClient>();
                //DataTable dt = Galatee.Entity.Model.FraudeProcedure.RetourneQualiteExpert();
                DataTable dt = DBParametrages.SelectAllDonneReference("frd.TYPECLIENT");
                _typeClientFraude = Entities.GetEntityListFromQuery<CsTypeClient>(dt);

                return _typeClientFraude;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        public List<CsPenalite> SelectAllPenalite()
        {
            try
            {
                List<CsPenalite> _stru = new List<CsPenalite>();
                //DataTable dt = Galatee.Entity.Model.FraudeProcedure.RetourneQualiteExpert();
                DataTable dt = DBParametrages.SelectAllDonneReference("frd.PENALITE");
                _stru = Entities.GetEntityListFromQuery<CsPenalite>(dt);

                return _stru;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        public List<CsDecisionfrd> SelectAllDecisionfrd()
        {
            try
            {
                List<CsDecisionfrd> _sDecisionfrd = new List<CsDecisionfrd>();
                //DataTable dt = Galatee.Entity.Model.FraudeProcedure.RetourneDecisonfrd();
                DataTable dt = DBParametrages.SelectAllDonneReference("frd.DECISIONFRAUDE");
                _sDecisionfrd = Entities.GetEntityListFromQuery<CsDecisionfrd>(dt);

                return _sDecisionfrd;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<CsControleur> SelectAllControleur()
        {
            try
            {
                List<CsControleur> _sOrganeFraude = new List<CsControleur>();
                //DataTable dt = Galatee.Entity.Model.FraudeProcedure.RetourneControleur();
                DataTable dt = DBParametrages.SelectAllDonneReference("frd.CONTROLEUR");
                _sOrganeFraude = Entities.GetEntityListFromQuery<CsControleur>(dt);

                return _sOrganeFraude;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #region Client Iweb

        public List<CsClient> SelectAllClientIWebs()
        {
            try
            {
                List<CsClient> _lstCsClient = new List<CsClient>();
                //DataTable dt = Galatee.Entity.Model.FraudeProcedure.RetourneListeMoyendeDenonciation();
                DataTable dt = DBParametrages.SelectAllDonneReference("frd.MOYENDENONCIATION");
                _lstCsClient = Entities.GetEntityListFromQuery<CsClient>(dt);
                return _lstCsClient;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<CsClient> RetourneClient(int fk_idcentre, string centre, string client,string Ordre)
        {
            //cmd.CommandText = "SPX_GUI_RETOURNE_ORDREMAX";
            try
            {
                List<CsClient> _Client = new List<CsClient>();
                DataTable dt = Galatee.Entity.Model.FraudeProcedure.RetourneClient(fk_idcentre, centre, client, Ordre);
                _Client = Entities.GetEntityListFromQuery<CsClient>(dt);
                return _Client;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public CsAbon RetourneClientByNumAbon(int fk_idcentre, string centre, string client, string NumeroAbonne)
        {
            try
            {
                DBAccueil DbAccueil = new DBAccueil();
                

                CsAbon leAbonnement = new CsAbon();
                leAbonnement = DbAccueil.Select_Abon(client, NumeroAbonne);

                if (leAbonnement != null )
                {
                    CsClient leClient = new CsClient();
                    leClient = DbAccueil.Select_client(leAbonnement.NUMEROABONNE);
                    leAbonnement.NUMEROABONNE = leAbonnement.NUMEROABONNE;
                    //leAbonnement.NOMABON  = String.Format("{0} {1}", string.IsNullOrEmpty(leClient.NOMABON) ? string.Empty : leClient.NOMABON, string.IsNullOrEmpty(leClient.PRENOM) ? string.Empty : leClient.PRENOM);
                    leAbonnement.NOMABON  = string.IsNullOrEmpty(leClient.NOMABON) ? string.Empty : leClient.NOMABON ;
                    leAbonnement.PRENON   = string.IsNullOrEmpty(leClient.PRENOM) ? string.Empty : leClient.PRENOM;
                    leAbonnement.TELEPHONE = leClient.TELEPHONE;
                    leAbonnement.TELEPHONEFIXE = leClient.TELEPHONEFIXE;
                    leAbonnement.ADRMAND1 = leClient.ADRMAND1;
                }
                return leAbonnement;

                //DataTable dt = Galatee.Entity.Model.FraudeProcedure.RetourneClient(fk_idcentre, centre, client, NumeroAbonne);
                //_Client = Entities.GetEntityListFromQuery<CsClient>(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        #endregion

        

        

      # region enregistrement

      public bool InsertControleFraude(CsDemandeFraude LaDemande)
     {
            
                SqlCommand cmds = DBBase.InitTransaction(ConnectString);
                try
                {
                    InsertOrUpdateCLIENTFRAUDE(LaDemande.ClientFraude, cmds);
                    InsertOrUpdateCONTROLE(LaDemande.Controle, cmds);

                    if (LaDemande.LstControleur != null && LaDemande.LstControleur.Count > 0)
                    {
                        DeleteCONTROLEUR(LaDemande.Controle.FK_IDFRAUDE.Value, cmds);

                        foreach (CsControleur st in LaDemande.LstControleur)
                        {
                            st.FK_IDFRAUDE = LaDemande.Fraude.PK_ID;
                            st.FicheControle = LaDemande.Controle.FicheControle;
                            InsertOrUpdateCONTROLEUR(st, cmds);
                        }
                    }

                    if (LaDemande.LstAnomaliesFraude != null && LaDemande.LstAnomaliesFraude.Count > 0)
                    {
                        DeleteANOMALIESFRAUDE(LaDemande.Controle.FK_IDFRAUDE.Value, cmds);

                        foreach (CsAnomaliesFraude st in LaDemande.LstAnomaliesFraude)
                        {
                            st.FK_IDFRAUDE = LaDemande.Fraude.PK_ID;
                            st.FicheControle = LaDemande.Controle.FicheControle;
                            InsertOrUpdateANOMALIESFRAUDE(st, cmds);
                        }
                    }
                    InsertOrUpdateCOMPTEUR(LaDemande.CompteurFraude, cmds);
                    InsertorUpdateAppareilRecense(LaDemande.AppareilRecenseFrd, cmds);
                    new DBAccueil().TransmettreDemande(LaDemande.LaDemande.NUMDEM, LaDemande.InfoDemande.FK_IDETAPEACTUELLE, LaDemande.LaDemande.MATRICULE, cmds); 
                    cmds.Transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    cmds.Transaction.Rollback();
                    throw new Exception(ex.Message);
                    return false;
                }

        }

      #endregion

   public string CreationDeFaude(CsDemandeFraude pDemandeFrd)
    {
        try
        {
            string DemandeID = string.Empty;

            SqlCommand cmds = DBBase.InitTransaction(ConnectString);

            try
            {
                if (pDemandeFrd.ClientFraude != null && pDemandeFrd.ClientFraude.Client == "0".PadLeft(Enumere.TailleClient, '0'))
                {
                    int Nombre = SelectNombreDemandeFraude(pDemandeFrd.ClientFraude.Centre);
                    string ReferenceClient = (pDemandeFrd.ClientFraude.Centre +"FR" + pDemandeFrd.LaDemande.USERCREATION  + Nombre.ToString("000")).PadLeft(Enumere.TailleClient,'0');
                    pDemandeFrd.ClientFraude.Client = ReferenceClient;
                    pDemandeFrd.LaDemande.CLIENT = ReferenceClient;
                }

                #region DEMANDE
                DBAccueil LeDB = new DBAccueil();
                pDemandeFrd.LaDemande.NUMDEM = LeDB.NumeroDemande(pDemandeFrd.LaDemande.FK_IDCENTRE);
                pDemandeFrd.Fraude.FicheTraitement = pDemandeFrd.LaDemande.NUMDEM;

                if (pDemandeFrd.LaDemande != null)
                    LeDB.InsertOrUpdateDemande(pDemandeFrd.LaDemande, cmds);



                #endregion
                #region CLIENTFRAUDE
                if (pDemandeFrd.ClientFraude != null)
                {
                    CsAg Ag = new DBAccueil().Select_Ag(pDemandeFrd.ClientFraude.Client);
                    pDemandeFrd.ClientFraude.FK_IDSITE = null;
                    if (Ag != null)
                    {
                        pDemandeFrd.ClientFraude.FK_IDCENTRE = Ag.FK_IDCENTRE;
                        pDemandeFrd.ClientFraude.Centre = Ag.CENTRE;

                        if (string.IsNullOrEmpty(pDemandeFrd.ClientFraude.Commune))
                            pDemandeFrd.ClientFraude.Commune = Ag.COMMUNE;

                        if (pDemandeFrd.ClientFraude.FK_IDCOMMUNE == null)
                            pDemandeFrd.ClientFraude.FK_IDCOMMUNE = Ag.FK_IDCOMMUNE;

                        if (pDemandeFrd.ClientFraude.FK_IDQUARTIER == null)
                            pDemandeFrd.ClientFraude.FK_IDQUARTIER = Ag.FK_IDQUARTIER;
                        if (string.IsNullOrEmpty(pDemandeFrd.ClientFraude.Quartier))
                            pDemandeFrd.ClientFraude.Quartier = Ag.QUARTIER;

                        pDemandeFrd.ClientFraude.FK_RUE = Ag.FK_IDRUE;
                        pDemandeFrd.ClientFraude.Rue = Ag.RUE;
                        if (pDemandeFrd.ClientFraude.FK_SECTEUR == null)
                            pDemandeFrd.ClientFraude.FK_SECTEUR = Ag.FK_IDSECTEUR;
                        pDemandeFrd.ClientFraude.FK_IDDEMANDE = pDemandeFrd.LaDemande.PK_ID;
                        if (string.IsNullOrEmpty(pDemandeFrd.ClientFraude.Secteur))
                            pDemandeFrd.ClientFraude.Secteur = Ag.SECTEUR;
                    }
                    else
                    {
                        pDemandeFrd.ClientFraude.FK_IDCOMMUNE = null ;
                        pDemandeFrd.ClientFraude.FK_IDQUARTIER = null;
                        pDemandeFrd.ClientFraude.FK_RUE = null;
                        pDemandeFrd.ClientFraude.FK_SECTEUR = null;
                        pDemandeFrd.ClientFraude.FK_IDDEMANDE = pDemandeFrd.LaDemande.PK_ID;
                    }
                    InsertOrUpdateCLIENTFRAUDE(pDemandeFrd.ClientFraude, cmds);
                }
                #endregion
                #region DENONCIATEUR
                //if (pDemandeFrd.Denonciateur != null)
                //{
                //    if( pDemandeFrd.Denonciateur.Nom ==null)
                //        pDemandeFrd.Denonciateur.Nom = "";
                //    pDemandeFrd.Denonciateur.FK_IDLOCALISATION = (int)pDemandeFrd.ClientFraude.FK_IDCENTRE;
                //    InsertDENONCIATEUR(pDemandeFrd.Denonciateur, cmds);
                //    //LstMoyenDenonc = SelectAllMoyenDenonciation();
                //    //pDemandeFrd.Denonciateur.FK_IDMOYENDENONCIATION = MoyenDenonc.PK_ID;
                //     pDemandeFrd.Denonciateur.FK_IDLOCALISATION = Ag.FK_IDCENTRE;

                //    //LstMoyenDenonc.Where(p=>p.PK_ID == MoyenDenonc

                //}
                #endregion

 
                 #region FRAUDE


                if (pDemandeFrd.Fraude != null)
                {
                    //pDemandeFrd.Fraude.FK_IDDENONCIATEUR = pDemandeFrd.Denonciateur.PK_ID;
                    pDemandeFrd.Fraude.FK_IDDECISIONFRAUDE = null;
                    //_FRAUDE.FK_IDSOURCECONTROLE = null;
                    pDemandeFrd.Fraude.FicheTraitement = pDemandeFrd.LaDemande.NUMDEM;
                    pDemandeFrd.Fraude.FK_IDDEMANDE = pDemandeFrd.LaDemande.PK_ID;
                    pDemandeFrd.Fraude.FK_IDCLIENTFRAUDE = pDemandeFrd.ClientFraude.PK_ID;
                    //InsertorUpdateDEMANDEFRAUDE(pDemandeFrd.Fraude, cmds);
                    InsertDEMANDEFRAUDE(pDemandeFrd.Fraude, cmds);
                }
                #endregion



                //string CodeWkF = pDemandeFrd.LaDemande.SITE + pDemandeFrd.LaDemande.CENTRE + DateTime.Today.Year + DateTime.Today.Month + DateTime.Today.Day + DateTime.Today.Hour +
                //                     DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond;
                //new DBAccueil().CreeDemande(pDemandeFrd.LaDemande.PK_ID, pDemandeFrd.LaDemande.NUMDEM, CodeWkF, cmds);
                

                ValiderDemandeControle(pDemandeFrd, cmds);

                cmds.Transaction.Commit();
                //return pDemandeFrd.LaDemande.PK_ID + "." + pDemandeFrd.LaDemande.NUMDEM;
                return pDemandeFrd.LaDemande.NUMDEM;


            }

            catch (Exception ex)
            {
                cmds.Transaction.Rollback();
                throw ex;
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

   enum StatutDemande
   {
       Annulée = 4,
       Finalisée = 6
   }

   public CsDemandeFraude CreationDeFaude(string Fiche, CsConsommationFrd cons)
   {
       try
       {
 
           CsDemandeFraude LaDemande = new CsDemandeFraude();
           string DemandeID = string.Empty;

           SqlCommand laCommande = null;

           try
           {
               List<CsAbon> lsAbon = new List<CsAbon>();
               LaDemande.InfoDemande = new DB_WORKFLOW().RecupererInfoDemandeParCodeTDem(Fiche);

               if (LaDemande.InfoDemande != null && 
                   (LaDemande.InfoDemande.CODEETAPE == "FRPV" ||
                   LaDemande.InfoDemande.CODEETAPE == "FRVC" ||
                   LaDemande.InfoDemande.FK_IDSTATUS == (int)StatutDemande.Annulée ||
                   LaDemande.InfoDemande.FK_IDSTATUS == (int)StatutDemande.Finalisée))
                   return LaDemande;


               LaDemande.Controle = SelectControleFraude(Fiche);
               LaDemande.ClientFraude = SelectClientFraude(Fiche, null);
               if (LaDemande.ClientFraude != null && !string.IsNullOrEmpty(LaDemande.ClientFraude.Client) && !LaDemande.ClientFraude.Client.Contains("FR"))
                   lsAbon = new DBAccueil().Select_Abon(LaDemande.ClientFraude.Client);

               if (lsAbon == null || lsAbon.FirstOrDefault(a => a.DRES == null) == null)
                   return null;

               LaDemande.LaDemande = new DBAccueil().Select_Demande(Fiche, null);
               //pDemandeFrd.InfoDemande = new DB_WORKFLOW().RecupererInfoDemandeParCodeTDem(_LaDemande.LaDemande.NUMDEM);
               LaDemande.Fraude = SelectFraude(LaDemande.LaDemande.NUMDEM, LaDemande.LaDemande.PK_ID);
               LaDemande.ClientFraude = SelectClientFraude(LaDemande.LaDemande.NUMDEM, LaDemande.LaDemande.PK_ID);
               LaDemande.Denonciateur = SelectDenonciateur(LaDemande.LaDemande.NUMDEM, LaDemande.LaDemande.PK_ID);
               LaDemande.CompteurFraude = SelectCompteurFraude(LaDemande.LaDemande.NUMDEM, LaDemande.LaDemande.PK_ID);
               LaDemande.Controle = SelectControleFraude(LaDemande.LaDemande.NUMDEM, LaDemande.LaDemande.PK_ID);
               LaDemande.AppareilRecenseFrd = SelectAppareilFraude(LaDemande.LaDemande.NUMDEM, LaDemande.LaDemande.PK_ID);
               LaDemande.LstControleur = SelectControleurFraude(LaDemande.LaDemande.NUMDEM, LaDemande.LaDemande.PK_ID);
               LaDemande.LstAnomaliesFraude = SelectAnomaliesFraude(LaDemande.LaDemande.NUMDEM, LaDemande.LaDemande.PK_ID);
               LaDemande.AuditionFraude = SelectAuditionFraude(LaDemande.LaDemande.NUMDEM, LaDemande.LaDemande.PK_ID);



               #region DEMANDE
               DBAccueil LeDB = new DBAccueil();
               LaDemande.LaDemande.NUMDEM = Fiche;
               LaDemande.Fraude.FicheTraitement = Fiche;





               #endregion

               #region DENONCIATEUR
               //if (pDemandeFrd.Denonciateur != null)
               //{
               //    if( pDemandeFrd.Denonciateur.Nom ==null)
               //        pDemandeFrd.Denonciateur.Nom = "";
               //    pDemandeFrd.Denonciateur.FK_IDLOCALISATION = (int)pDemandeFrd.ClientFraude.FK_IDCENTRE;
               //    InsertDENONCIATEUR(pDemandeFrd.Denonciateur, cmds);
               //    //LstMoyenDenonc = SelectAllMoyenDenonciation();
               //    //pDemandeFrd.Denonciateur.FK_IDMOYENDENONCIATION = MoyenDenonc.PK_ID;
               //     pDemandeFrd.Denonciateur.FK_IDLOCALISATION = Ag.FK_IDCENTRE;

               //    //LstMoyenDenonc.Where(p=>p.PK_ID == MoyenDenonc

               //}
               #endregion

               laCommande = DBBase.InitTransaction(ConnectString);

               string CodeWkF = LaDemande.LaDemande.SITE + LaDemande.LaDemande.CENTRE + DateTime.Today.Year + DateTime.Today.Month + DateTime.Today.Day + DateTime.Today.Hour +
                                    DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond;

               if (LaDemande.InfoDemande == null)
                   new DBAccueil().CreeDemande(LaDemande.LaDemande.PK_ID, LaDemande.LaDemande.NUMDEM, CodeWkF, laCommande);

               LaDemande.ConsommationFrd = new CsConsommationFrd();
               LaDemande.ConsommationFrd = cons;



               DBAccueil Db = new DBAccueil();
               //Db.TransmettreDemande(LaDemande.LaDemande.NUMDEM, LaDemande.InfoDemande.FK_IDETAPEACTUELLE, LaDemande.LaDemande.MATRICULE, laCommande);
               //if (!string.IsNullOrEmpty( LaDemande.ClientFraude.NUMEROABONNE) )
               //{
               CsEvenement leEvtFraude = new CsEvenement
               {
                   CENTRE = LaDemande.ClientFraude.Centre,
                   FK_IDCENTRE = LaDemande.ClientFraude.FK_IDCENTRE.Value,
                   PUISSANCE = LaDemande.ClientFraude.PuissanceSouscrite,
                   PRODUIT = LaDemande.CompteurFraude.PRODUIT,
                   FK_IDPRODUIT = LaDemande.CompteurFraude.FK_IDPRODUIT.Value,
                   LOTRI = LaDemande.LaDemande.CENTRE + "00005",
                   NUMEROABONNE = LaDemande.ClientFraude.NUMEROABONNE,
                   NUMDEM = LaDemande.LaDemande.NUMDEM,
                   FK_IDDEMANDE = LaDemande.LaDemande.PK_ID,
                   PERIODE = LaDemande.ConsommationFrd.PERIODEFIN,
                   PERIODEPRECEDENTEFACTURE = LaDemande.ConsommationFrd.PERIODEDEBUT,
                   INDEXEVTPRECEDENT = 0,
                   DATEEVT = System.DateTime.Today.Date,
                   FK_IDABON = LaDemande.ClientFraude.FK_IDABON,
                   USERCREATION = LaDemande.LaDemande.MATRICULE,
                   TYPETARIF = LaDemande.ClientFraude.TYPETARIF,
                   PHASECOMPTEUR = LaDemande.CompteurFraude.PHASE,
                   CONSO = LaDemande.ConsommationFrd.ConsommationAFacturer,
                   CLIENT = LaDemande.ClientFraude.Client,
                   COMPTEUR = LaDemande.CompteurFraude.NumeroCompteur,
                   CAS = Enumere.CasNormal,
                   ORDRE = LaDemande.ClientFraude.Ordre,
                   STATUS = Enumere.EvenementReleve,
                   MATRICULE = LaDemande.LaDemande.MATRICULE,
                   POINT = 1
               };

               CsLotri NewLotri = new CsLotri()
               {
                   BASE = "S",
                   CATEGORIECLIENT = "99",
                   CENTRE = leEvtFraude.CENTRE,
                   FK_IDCENTRE = leEvtFraude.FK_IDCENTRE,
                   DATECREATION = DateTime.Now,
                   FK_IDCATEGORIECLIENT = null,
                   FK_IDPRODUIT = leEvtFraude.FK_IDPRODUIT,
                   FK_IDRELEVEUR = null,
                   NUMLOTRI = leEvtFraude.LOTRI,
                   PERIODE = DateTime.Now.Year + (DateTime.Now.Month.ToString().Length > 1 ? DateTime.Now.Month.ToString() : "0" + DateTime.Now.Month.ToString()),
                   PERIODICITE = "01",
                   PRODUIT = leEvtFraude.PRODUIT,
                   RELEVEUR = "99",
                   TOURNEE = "000",
                   USERCREATION = leEvtFraude.USERCREATION,
                   UserCalcul = leEvtFraude.USERCREATION
               };
               Db.InsertOrUpdateLotri(NewLotri, laCommande);
               Db.InsertOrUpdateEVENEMENT(leEvtFraude, laCommande);

               LaDemande.ConsommationFrd.FK_IDFRAUDE = LaDemande.Fraude.PK_ID;
               LaDemande.ConsommationFrd.FK_IDPRODUIT = LaDemande.CompteurFraude.FK_IDPRODUIT.Value;
               InsertorUpdateCONSOMMAION(LaDemande.ConsommationFrd, laCommande);
               CreationCtarCompt(leEvtFraude.NUMDEM, leEvtFraude.LOTRI, leEvtFraude.PERIODE, leEvtFraude.USERCREATION, leEvtFraude.FK_IDCENTRE, leEvtFraude.FK_IDPRODUIT, leEvtFraude.DATEEVT, laCommande);


               laCommande.Transaction.Commit();
               return LaDemande;


           }

           catch (Exception ex)
           {
               laCommande.Transaction.Rollback();
               throw ex;
           }
       }
       catch (Exception ex)
       {
           throw new Exception(ex.Message);
       }
   }



   public CsDemandeFraude RetourneFiche(string Fiche)
   {
       try
       {
           CsDemandeFraude LaDemande = new CsDemandeFraude();
           string DemandeID = string.Empty;

           try
           {
               List<CsAbon> lsAbon = new List<CsAbon>();
               LaDemande.InfoDemande = new DB_WORKFLOW().RecupererInfoDemandeParCodeTDem(Fiche);


               LaDemande.Controle = SelectControleFraude(Fiche);
               LaDemande.ClientFraude = SelectClientFraude(Fiche, null);
               if (LaDemande.ClientFraude != null && !string.IsNullOrEmpty(LaDemande.ClientFraude.Client) && !LaDemande.ClientFraude.Client.Contains("FR"))
                   lsAbon = new DBAccueil().Select_Abon(LaDemande.ClientFraude.Client);


               LaDemande.LaDemande = new DBAccueil().Select_Demande(Fiche, null);
               LaDemande.Fraude = SelectFraude(LaDemande.LaDemande.NUMDEM, LaDemande.LaDemande.PK_ID);
               LaDemande.ClientFraude = SelectClientFraude(LaDemande.LaDemande.NUMDEM, LaDemande.LaDemande.PK_ID);
               LaDemande.Denonciateur = SelectDenonciateur(LaDemande.LaDemande.NUMDEM, LaDemande.LaDemande.PK_ID);
               LaDemande.CompteurFraude = SelectCompteurFraude(LaDemande.LaDemande.NUMDEM, LaDemande.LaDemande.PK_ID);
               LaDemande.Controle = SelectControleFraude(LaDemande.LaDemande.NUMDEM, LaDemande.LaDemande.PK_ID);
               LaDemande.AppareilRecenseFrd = SelectAppareilFraude(LaDemande.LaDemande.NUMDEM, LaDemande.LaDemande.PK_ID);
               LaDemande.AppareilUtiliserFrd = SelectAppareilUtiliserFraude(LaDemande.LaDemande.NUMDEM, LaDemande.LaDemande.PK_ID);
               if (LaDemande.AppareilUtiliserFrd != null && LaDemande.AppareilUtiliserFrd.Count > 0)
                   LaDemande.AppareilUtiliserFrd.ForEach(a => a.NOMBRE = a.EMPORTE);

               LaDemande.LstControleur = SelectControleurFraude(LaDemande.LaDemande.NUMDEM, LaDemande.LaDemande.PK_ID);
               LaDemande.LstAnomaliesFraude = SelectAnomaliesFraude(LaDemande.LaDemande.NUMDEM, LaDemande.LaDemande.PK_ID);
               LaDemande.AuditionFraude = SelectAuditionFraude(LaDemande.LaDemande.NUMDEM, LaDemande.LaDemande.PK_ID);



               LaDemande.LaDemande.NUMDEM = Fiche;
               LaDemande.Fraude.FicheTraitement = Fiche;

               return LaDemande;
           }

           catch (Exception ex)
           {
               throw ex;
           }
       }
       catch (Exception ex)
       {
           throw new Exception(ex.Message);
       }
   }



    public CsDemandeFraude RetourneLaDemande(int fk_demande)
    {
        //cmd.CommandText = "SPX_GUI_RETOURNE_DEMANDE";
        CsDemandeFraude _LaDemande = new CsDemandeFraude();

        try
        {
            _LaDemande.LaDemande = new DBAccueil().Select_Demande(string.Empty, fk_demande);
            _LaDemande.InfoDemande = new DB_WORKFLOW().RecupererInfoDemandeParCodeTDem(_LaDemande.LaDemande.NUMDEM);
            _LaDemande.Fraude = SelectFraude(_LaDemande.LaDemande.NUMDEM ,_LaDemande.LaDemande.PK_ID  );
            _LaDemande.ClientFraude = SelectClientFraude(_LaDemande.LaDemande.NUMDEM ,_LaDemande.LaDemande.PK_ID );
            _LaDemande.Denonciateur = SelectDenonciateur(_LaDemande.LaDemande.NUMDEM ,_LaDemande.LaDemande.PK_ID );
            _LaDemande.CompteurFraude = SelectCompteurFraude(_LaDemande.LaDemande.NUMDEM ,_LaDemande.LaDemande.PK_ID );
            _LaDemande.Controle = SelectControleFraude(_LaDemande.LaDemande.NUMDEM, _LaDemande.LaDemande.PK_ID);
            _LaDemande.AppareilRecenseFrd = SelectAppareilFraude(_LaDemande.LaDemande.NUMDEM, _LaDemande.LaDemande.PK_ID);
            _LaDemande.AppareilUtiliserFrd = SelectAppareilUtiliserFraude(_LaDemande.LaDemande.NUMDEM, _LaDemande.LaDemande.PK_ID);
            if (_LaDemande.AppareilUtiliserFrd != null && _LaDemande.AppareilUtiliserFrd.Count > 0)
                _LaDemande.AppareilUtiliserFrd.ForEach(a => a.NOMBRE = a.EMPORTE);
            
            _LaDemande.LstControleur = SelectControleurFraude(_LaDemande.LaDemande.NUMDEM, _LaDemande.LaDemande.PK_ID);
            _LaDemande.LstAnomaliesFraude = SelectAnomaliesFraude(_LaDemande.LaDemande.NUMDEM, _LaDemande.LaDemande.PK_ID);
            _LaDemande.AuditionFraude = SelectAuditionFraude(_LaDemande.LaDemande.NUMDEM, _LaDemande.LaDemande.PK_ID);
            //_LaDemande.AppareilUtiliserFrd = SelectAppareilUtiliserFraude(_LaDemande.LaDemande.NUMDEM, _LaDemande.LaDemande.PK_ID);
            _LaDemande.ConsommationFrd = SelectConsommatioFraude(_LaDemande.LaDemande.NUMDEM, _LaDemande.LaDemande.PK_ID);
            if (!_LaDemande.ClientFraude.Client.Contains("FR"))
            {
                _LaDemande.Ag = new DBAccueil().Select_Ag(_LaDemande.LaDemande.CLIENT);
                _LaDemande.Abon = new DBAccueil().Select_Abon(_LaDemande.LaDemande.CLIENT, _LaDemande.ClientFraude.NUMEROABONNE);
                _LaDemande.Canalisation = new DBAccueil().Select_CannalisationCompteur(_LaDemande.Abon.PK_ID).FirstOrDefault();
            }
            if (_LaDemande.InfoDemande.CODEETAPE == "FREM")
            {
                _LaDemande.PrestationRemboursable = SelectPrestationRemboursable();
                _LaDemande.Prestastionfrd = SelectPrestationFraude();
                _LaDemande.Regularisation  = SelectRegularisation(_LaDemande.CompteurFraude.FK_IDPHASECOMPTEUR );
                {
                    DataTable dt = CalculeDuLotSpx(_LaDemande.ClientFraude.Centre + Enumere.LotriFraude, _LaDemande.ConsommationFrd.PERIODEFIN, 1, false, _LaDemande.ConsommationFrd.USERCREATION, false, true, _LaDemande.Fraude.FicheTraitement );
                    List<CsFactureBrut> lstFacture = Tools.Utility.GetEntityListFromQuery<CsFactureBrut>(dt);
                    List<CsDETAILparTRANCHE> lstRedfacClient = Tools.Utility.ConvertListType<CsDETAILparTRANCHE, CsFactureBrut>(lstFacture);

                    List<CsRedevance> _laRedevance = Entities.GetEntityListFromQuery<CsRedevance>(DBParametrages.SelectAllDonneReference("REDEVANCE"));
                    foreach (CsDETAILparTRANCHE item in lstRedfacClient)
                        item.LIBELLEREDEVANCE = _laRedevance.FirstOrDefault(o => o.CODE == item.REDEVANCE && o.PRODUIT == item.PRODUIT).LIBELLE;
                    
                    _LaDemande.DETAILparTRANCHE = lstRedfacClient;
                  
                }
            }
            if (_LaDemande.InfoDemande.CODEETAPE == "FRVC" ||
                _LaDemande.InfoDemande.CODEETAPE == "FRPV")
            {
                _LaDemande.DETAILparPRESTATIONREMBOURSABLE = SelectDetailPrestationRemboursable(_LaDemande.Fraude.PK_ID);
                _LaDemande.DetailParPresentationEdm  = SelectDetailPrestationEdm (_LaDemande.Fraude.PK_ID );
                _LaDemande.DETAILparREGULARISATION  = SelectDetailRegarisation(_LaDemande.Fraude.PK_ID);
                _LaDemande.DETAILparTRANCHE = SelectDetailTranche(_LaDemande.Fraude.PK_ID);
            }
            return _LaDemande;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }




    public string EnregistrerFicheControle(CsDemandeFraude LaDemande)
    {
        try
        {
            string DemandeID = string.Empty;

            SqlCommand cmds = DBBase.InitTransaction(ConnectString);

            try
            {
                DBAccueil LeDB = new DBAccueil();
                LaDemande.LaDemande.DATEMODIFICATION = DateTime.Now;
                LeDB.InsertOrUpdateDemande(LaDemande.LaDemande, cmds);

                if (LaDemande.ClientFraude != null)
                    InsertOrUpdateCLIENTFRAUDE(LaDemande.ClientFraude, cmds);


                if (LaDemande.Fraude != null)
                    UpdateDEMANDEFRAUDE(LaDemande.Fraude, cmds);



                InsertOrUpdateCONTROLE(LaDemande.Controle, cmds);

                if (LaDemande.LstControleur != null && LaDemande.LstControleur.Count > 0)
                {
                    DeleteCONTROLEUR(LaDemande.Controle.FK_IDFRAUDE.Value, cmds);

                    foreach (CsControleur st in LaDemande.LstControleur)
                    {
                        st.FK_IDFRAUDE = LaDemande.Fraude.PK_ID;
                        st.FicheControle = LaDemande.Controle.FicheControle;
                        InsertOrUpdateCONTROLEUR(st, cmds);
                    }
                }


                if (LaDemande.LstAnomaliesFraude != null && LaDemande.LstAnomaliesFraude.Count > 0)
                {
                    DeleteANOMALIESFRAUDE(LaDemande.Controle.FK_IDFRAUDE.Value, cmds);

                    foreach (CsAnomaliesFraude st in LaDemande.LstAnomaliesFraude)
                    {
                        st.FK_IDFRAUDE = LaDemande.Fraude.PK_ID;
                        st.FicheControle = LaDemande.Controle.FicheControle;
                        InsertOrUpdateANOMALIESFRAUDE(st, cmds);
                    }
                }


                InsertOrUpdateCOMPTEUR(LaDemande.CompteurFraude, cmds);

                if (LaDemande.AppareilRecenseFrd != null)
                {
                    LaDemande.AppareilRecenseFrd.ForEach(a => a.FK_IDFRAUDE = LaDemande.Fraude.PK_ID);
                    LaDemande.AppareilRecenseFrd.ForEach(a => a.FicheControle = LaDemande.Controle.FicheControle);
                    InsertorUpdateAppareilRecense(LaDemande.AppareilRecenseFrd, cmds);
                }


                if (LaDemande.AppareilUtiliserFrd != null)
                {
                    LaDemande.AppareilUtiliserFrd.ForEach(a => a.FK_IDFRAUDE = LaDemande.Fraude.PK_ID);
                    LaDemande.AppareilUtiliserFrd.ForEach(a => a.FicheControle = LaDemande.Controle.FicheControle);
                    LaDemande.AppareilUtiliserFrd.ForEach(a => a.EMPORTE = a.NOMBRE);
                    InsertorUpdateAppareilUtlise(LaDemande.AppareilUtiliserFrd, cmds);
                }


                if (LaDemande.AuditionFraude != null)
                {
                    LaDemande.AuditionFraude.FK_IDFRAUDE = LaDemande.Fraude.PK_ID;
                    LaDemande.AuditionFraude.FicheControle = LaDemande.Controle.FicheControle;
                    InsertorUpdateAUDITIONFRAUDE(LaDemande.AuditionFraude, cmds);
                }
                cmds.Transaction.Commit();

                return LaDemande.LaDemande.NUMDEM;

            }

            catch (Exception ex)
            {
                cmds.Transaction.Rollback();
                throw ex;
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }


    public bool EnregistrerAppareilRestitue(List<CsAppareilUtiliserFrd> LesAppareils)
    {
        try
        {
            SqlCommand cmds = DBBase.InitTransaction(ConnectString);

            try
            {
                UpdateAppareilRestitue(LesAppareils, cmds);
                cmds.Transaction.Commit();

                return true;

            }
            catch (Exception ex)
            {
                cmds.Transaction.Rollback();
                throw ex;
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }



    public List<CsFactureClient> ValiderDemandeFraude(CsDemandeFraude LaDemande)
    {
        try
        {
            //ZEG 30/04/2019
            //if (LaDemande.InfoDemande.CODEETAPE == "FRPC")
                //return ValiderDemandeControle(LaDemande);
            //else if (LaDemande.InfoDemande.CODEETAPE == "FRPA")
                //return ValiderDemandeAudition(LaDemande);
            //else 

            List<CsFactureClient> factures = new List<CsFactureClient>();

            if (LaDemande.InfoDemande.CODEETAPE == "FRAD")
                ValiderDemandeConsommation(LaDemande);
            else if (LaDemande.InfoDemande.CODEETAPE == "FREM")
                factures = ValiderDemandeEmissionFacture(LaDemande);
            else if (LaDemande.InfoDemande.CODEETAPE == "FRPV")
                ValiderDemandePrevisualisation(LaDemande);
            else if (LaDemande.InfoDemande.CODEETAPE == "FRVC")
                ValiderDemandeMiseAjourFacture(LaDemande);

            return factures;
        }
        catch (Exception ex)
        {
            return  null ;
        }
    }

    public string ValiderDemandePrevisualisation(CsDemandeFraude LaDemande)
    {
        SqlCommand laCommande = DBBase.InitTransaction(ConnectionString);
        try
        {
            new DBAccueil().TransmettreDemande(LaDemande.LaDemande.NUMDEM, LaDemande.InfoDemande.FK_IDETAPEACTUELLE, LaDemande.LaDemande.MATRICULE, laCommande);
            laCommande.Transaction.Commit();
            return "";
        }
        catch (Exception ex)
        {
            laCommande.Transaction.Rollback();
            return ex.Message;
        }
        finally
        {
            if (laCommande.Connection.State == ConnectionState.Open)
                laCommande.Connection.Close(); // Fermeture de la connection 
            laCommande.Dispose();
        }
    }


    public string ValiderDemandeControle(CsDemandeFraude LaDemande, SqlCommand laCommande)
    {
        //SqlCommand laCommande = DBBase.InitTransaction(ConnectionString);
        try
        {
            InsertOrUpdateCLIENTFRAUDE(LaDemande.ClientFraude, laCommande);
            
            LaDemande.Controle.FK_IDCLIENTFRAUDE = LaDemande.ClientFraude.PK_ID;
            LaDemande.Controle.FK_IDFRAUDE = LaDemande.Fraude.PK_ID;

            LaDemande.Controle.FicheControle = LaDemande.LaDemande.NUMDEM;
            InsertOrUpdateCONTROLE(LaDemande.Controle, laCommande);

            if (LaDemande.LstControleur != null && LaDemande.LstControleur.Count > 0)
            {
                DeleteCONTROLEUR(LaDemande.Controle.FK_IDFRAUDE.Value, laCommande);

                foreach (CsControleur st in LaDemande.LstControleur)
                {
                    st.FK_IDFRAUDE = LaDemande.Fraude.PK_ID;
                    st.FicheControle = LaDemande.Controle.FicheControle;
                    InsertOrUpdateCONTROLEUR(st, laCommande);
                }
            }


            if (LaDemande.LstAnomaliesFraude != null && LaDemande.LstAnomaliesFraude.Count > 0)
            {
                DeleteANOMALIESFRAUDE(LaDemande.Controle.FK_IDFRAUDE.Value, laCommande);

                foreach (CsAnomaliesFraude st in LaDemande.LstAnomaliesFraude)
                {
                    st.FK_IDFRAUDE = LaDemande.Fraude.PK_ID;
                    st.FicheControle = LaDemande.Controle.FicheControle;
                    InsertOrUpdateANOMALIESFRAUDE(st, laCommande);
                }
            }

            //LaDemande.Controleur.FK_IDFRAUDE = LaDemande.Fraude.PK_ID;
            //LaDemande.Controleur.FicheControle = LaDemande.Controle.FicheControle;
            //InsertOrUpdateCONTROLEUR(LaDemande.Controleur, laCommande);

            LaDemande.CompteurFraude.FK_IDCONTROLE = LaDemande.Controle.PK_ID;
            LaDemande.CompteurFraude.FK_IDCLIENTFRAUDE = LaDemande.ClientFraude.PK_ID;

            InsertOrUpdateCOMPTEUR(LaDemande.CompteurFraude, laCommande);

            if (LaDemande.AppareilRecenseFrd != null)
            {
                LaDemande.AppareilRecenseFrd.ForEach(a => a.FK_IDFRAUDE = LaDemande.Fraude.PK_ID);
                LaDemande.AppareilRecenseFrd.ForEach(a => a.FicheControle = LaDemande.Controle.FicheControle);
                InsertorUpdateAppareilRecense(LaDemande.AppareilRecenseFrd, laCommande);
            }


            if (LaDemande.AppareilUtiliserFrd != null)
            {
                LaDemande.AppareilUtiliserFrd.ForEach(a => a.FK_IDFRAUDE = LaDemande.Fraude.PK_ID);
                LaDemande.AppareilUtiliserFrd.ForEach(a => a.FicheControle = LaDemande.Controle.FicheControle);
                LaDemande.AppareilUtiliserFrd.ForEach(a => a.EMPORTE = a.NOMBRE);
                InsertorUpdateAppareilUtlise(LaDemande.AppareilUtiliserFrd, laCommande);
            }


            if (LaDemande.AuditionFraude != null)
            {
                LaDemande.AuditionFraude.FK_IDFRAUDE = LaDemande.Fraude.PK_ID;
                LaDemande.AuditionFraude.FicheControle = LaDemande.Controle.FicheControle;
                InsertorUpdateAUDITIONFRAUDE(LaDemande.AuditionFraude, laCommande);
            }





            //new DBAccueil().TransmettreDemande(LaDemande.LaDemande.NUMDEM, LaDemande.InfoDemande.FK_IDETAPEACTUELLE, LaDemande.LaDemande.MATRICULE, laCommande);
            //laCommande.Transaction.Commit();
                return "";
        }
        catch (Exception ex)
        {
            //laCommande.Transaction.Rollback();
            throw ex;
        }
        //finally
        //{
        //    if (laCommande.Connection.State == ConnectionState.Open)
        //        laCommande.Connection.Close(); // Fermeture de la connection 
        //    laCommande.Dispose();

        //}
    }


    public string ValiderDemandeAudition(CsDemandeFraude LaDemande)
    {
        SqlCommand laCommande = DBBase.InitTransaction(ConnectionString);
        try
        {
            if (LaDemande.AppareilUtiliserFrd  != null )
            InsertorUpdateAppareilUtlise (LaDemande.AppareilUtiliserFrd , laCommande);

            if (LaDemande.AuditionFraude != null)
            InsertorUpdateAUDITIONFRAUDE(LaDemande.AuditionFraude, laCommande);

            new DBAccueil().TransmettreDemande(LaDemande.LaDemande.NUMDEM, LaDemande.InfoDemande.FK_IDETAPEACTUELLE, LaDemande.LaDemande.MATRICULE, laCommande);
            laCommande.Transaction.Commit();
            return "";
        }
        catch (Exception ex)
        {
            laCommande.Transaction.Rollback();
            return ex.Message;
        }
        finally
        {
            if (laCommande.Connection.State == ConnectionState.Open)
                laCommande.Connection.Close(); // Fermeture de la connection 
            laCommande.Dispose();
        }
    }

    public string ValiderDemandeConsommation(CsDemandeFraude LaDemande)
    {
        SqlCommand laCommande = DBBase.InitTransaction(ConnectionString);
        try
        {
                 DBAccueil Db = new DBAccueil();
                 Db.TransmettreDemande(LaDemande.LaDemande.NUMDEM, LaDemande.InfoDemande.FK_IDETAPEACTUELLE, LaDemande.LaDemande.MATRICULE, laCommande);
                    //if (!string.IsNullOrEmpty( LaDemande.ClientFraude.NUMEROABONNE) )
                    //{
                        CsEvenement leEvtFraude = new CsEvenement {
                            CENTRE = LaDemande.ClientFraude.Centre,
                            FK_IDCENTRE = LaDemande.ClientFraude.FK_IDCENTRE.Value ,
                            PUISSANCE  = LaDemande.ClientFraude.PuissanceSouscrite ,
                            PRODUIT  = LaDemande.CompteurFraude.PRODUIT,
                            FK_IDPRODUIT   = LaDemande.CompteurFraude.FK_IDPRODUIT.Value ,
                            LOTRI = LaDemande.LaDemande.CENTRE + "00005",
                            NUMEROABONNE   = LaDemande.ClientFraude.NUMEROABONNE ,
                            NUMDEM = LaDemande.LaDemande.NUMDEM  ,
                            FK_IDDEMANDE = LaDemande.LaDemande.PK_ID ,
                            PERIODE   = LaDemande.ConsommationFrd.PERIODEFIN ,
                            PERIODEPRECEDENTEFACTURE = LaDemande.ConsommationFrd.PERIODEDEBUT,
                            INDEXEVTPRECEDENT = 0,
                            DATEEVT = System.DateTime.Today.Date ,
                            FK_IDABON  = LaDemande.ClientFraude.FK_IDABON,
                            USERCREATION = LaDemande.LaDemande.MATRICULE,  
                            TYPETARIF  = LaDemande.ClientFraude.TYPETARIF ,
                            PHASECOMPTEUR = LaDemande.CompteurFraude.PHASE,
                            CONSO =LaDemande.ConsommationFrd.ConsommationAFacturer ,
                            CLIENT = LaDemande.ClientFraude.Client ,
                            COMPTEUR =LaDemande.CompteurFraude.NumeroCompteur ,
                            CAS = Enumere.CasNormal, 
                            ORDRE  =LaDemande.ClientFraude.Ordre ,
                            STATUS = Enumere.EvenementReleve ,
                            MATRICULE = LaDemande.LaDemande.MATRICULE 
                        };

                    CsLotri NewLotri = new CsLotri()
                    {
                        BASE = "S",
                        CATEGORIECLIENT = "99",
                        CENTRE = leEvtFraude.CENTRE,
                        FK_IDCENTRE = leEvtFraude.FK_IDCENTRE,
                        DATECREATION = DateTime.Now,
                        FK_IDCATEGORIECLIENT = null,
                        FK_IDPRODUIT = leEvtFraude.FK_IDPRODUIT,
                        FK_IDRELEVEUR = null,
                        NUMLOTRI = leEvtFraude.LOTRI,
                        PERIODE = DateTime.Now.Year + (DateTime.Now.Month.ToString().Length > 1 ? DateTime.Now.Month.ToString() : "0" + DateTime.Now.Month.ToString()),
                        PERIODICITE = "01",
                        PRODUIT = leEvtFraude.PRODUIT,
                        RELEVEUR = "99",
                        TOURNEE = "000",
                        USERCREATION = leEvtFraude.USERCREATION,
                        UserCalcul = leEvtFraude.USERCREATION
                    };
                Db.InsertOrUpdateLotri(NewLotri, laCommande);
                Db.InsertOrUpdateEVENEMENT(leEvtFraude, laCommande);
                InsertorUpdateCONSOMMAION(LaDemande.ConsommationFrd, laCommande);
                CreationCtarCompt(leEvtFraude.NUMDEM , leEvtFraude.LOTRI, leEvtFraude.PERIODE, leEvtFraude.USERCREATION, leEvtFraude.FK_IDCENTRE, leEvtFraude.FK_IDPRODUIT, leEvtFraude.DATEEVT, laCommande);
            //}
            laCommande.Transaction.Commit();
            return "";
        }
        catch (Exception ex)
        {
            laCommande.Transaction.Rollback();
            return ex.Message;
        }
        finally
        {
            if (laCommande.Connection.State == ConnectionState.Open)
                laCommande.Connection.Close(); // Fermeture de la connection 
            laCommande.Dispose();
        }
    }

    public void CreationCtarCompt(string NumDemande, string lotri, string periode, string Matricule, int idcentre, int idproduit, DateTime? dateEvt, SqlCommand cmds)
    {

        cmds.CommandTimeout = 360;
        cmds.CommandType = CommandType.StoredProcedure;
        if (cmds.Parameters != null && cmds.Parameters.Count != 0) cmds.Parameters.Clear();
        cmds.CommandText = "SPX_CREATION_CTARCOMP_FRD";
        cmds.Parameters.Add("@NUMDEMANDE", SqlDbType.VarChar ,20).Value = NumDemande;
        cmds.Parameters.Add("@Lotri", SqlDbType.VarChar, 8).Value = lotri;
        cmds.Parameters.Add("@Periode", SqlDbType.VarChar, 8).Value = periode;
        cmds.Parameters.Add("@Matricule", SqlDbType.VarChar, 6).Value = Matricule;
        cmds.Parameters.Add("@IdCentre", SqlDbType.Int).Value = idcentre;
        cmds.Parameters.Add("@IdProduit", SqlDbType.Int).Value = idproduit;
        cmds.Parameters.Add("@DateEvt", SqlDbType.DateTime).Value = dateEvt;

        int Insere = -1;
        DBBase.SetDBNullParametre(cmds.Parameters);
        try
        {

            Insere = cmds.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw new Exception(cmds.CommandText + ":" + ex.Message);
        }

    }

    public List<CsFactureClient> ValiderDemandeEmissionFacture(CsDemandeFraude LaDemande)
    {
        List<CsFactureClient> factures = new List<CsFactureClient>();
        SqlCommand laCommande = DBBase.InitTransaction(ConnectionString);
        try
        {
            CsLotri lot = new CsLotri();
            lot.NUMLOTRI = LaDemande.ClientFraude.Centre + "00005";
            lot.PRODUIT = LaDemande.DETAILparTRANCHE.FirstOrDefault().PRODUIT;
            lot.FK_IDPRODUIT = LaDemande.DETAILparTRANCHE.FirstOrDefault().FK_IDPRODUIT;

            LaDemande.DETAILparTRANCHE.ForEach(a => a.FK_IDFRAUDE = LaDemande.Fraude.PK_ID);

            SupprimerDetail(LaDemande.Fraude.PK_ID, laCommande);

            InsertorUpdateDetailTranche(LaDemande.DETAILparTRANCHE, laCommande);
            InsertorUpdateDetailPrestation(LaDemande.DetailParPresentationEdm, laCommande);
            InsertorUpdateDetailPrestationRemboursable(LaDemande.DETAILparPRESTATIONREMBOURSABLE, laCommande);
            InsertorUpdateDetailRegarisation(LaDemande.DETAILparREGULARISATION, laCommande);
            ValiderCalcul(LaDemande.LaDemande.NUMDEM, laCommande);
            new DBAccueil().TransmettreDemande(LaDemande.LaDemande.NUMDEM, LaDemande.InfoDemande.FK_IDETAPEACTUELLE, LaDemande.LaDemande.MATRICULE, laCommande);
            laCommande.Transaction.Commit();

            factures = new DbFacturation().RetourneFactureFraude(lot, LaDemande.ClientFraude.FK_IDCENTRE.Value, LaDemande.ClientFraude.Client, LaDemande.LaDemande.NUMDEM);
            return factures;
        }
        catch (Exception ex)
        {
            laCommande.Transaction.Rollback();
            return null;
        }
        finally
        {
            if (laCommande.Connection.State == ConnectionState.Open)
                laCommande.Connection.Close(); // Fermeture de la connection 
            laCommande.Dispose();
        }
    }


    public string ValiderDemandeMiseAjourFacture(CsDemandeFraude LaDemande)
    {
        SqlCommand laCommande = DBBase.InitTransaction(ConnectionString);
        try
        {
            string lot = LaDemande.ClientFraude.Centre + "00005";

            ValiderFactureFraude(lot, LaDemande.LaDemande.NUMDEM, LaDemande.LaDemande.MATRICULE , laCommande);
            new DBAccueil().TransmettreDemande(LaDemande.LaDemande.NUMDEM, LaDemande.InfoDemande.FK_IDETAPEACTUELLE, LaDemande.LaDemande.MATRICULE, laCommande);
            laCommande.Transaction.Commit();
            return "";
        }
        catch (Exception ex)
        {
            laCommande.Transaction.Rollback();
            return ex.Message;
        }
        finally
        {
            if (laCommande.Connection.State == ConnectionState.Open)
                laCommande.Connection.Close(); // Fermeture de la connection 
            laCommande.Dispose();
        }
    }


    //public string ValiderDemandeControleIndex(CsDemandeFraude LaDemande)
    //{
    //    try
    //    {


    //        string DemandeID = string.Empty;
    //        bool Resultat = false;
    //        int resultTransaction = -1;
    //        using (galadbEntities transaction = new galadbEntities())
    //        {

    //            try
    //            {

    //                //LaDemande.LaDemande.NUMDEM = AccueilProcedures.GetNumDevis(LaDemande.LaDemande);
    //                //LaDemande.Fraude.FicheTraitement = LaDemande.LaDemande.NUMDEM;

    //                LaDemande.Fraude.FicheTraitement = LaDemande.LaDemande.NUMDEM;
    //                LaDemande.Fraude.FK_IDDEMANDE = LaDemande.LaDemande.PK_ID;

    //                FraudeProcedure.InsertionControleIndex(LaDemande, transaction);
    //                resultTransaction = transaction.SaveChanges();
    //                if (resultTransaction != -1)
    //                {
    //                    LaDemande.LaDemande.PK_ID = transaction.DEMANDE.FirstOrDefault(d => d.NUMDEM == LaDemande.LaDemande.NUMDEM && d.CENTRE == LaDemande.LaDemande.CENTRE).PK_ID;
    //                    if (LaDemande.LaDemande.PK_ID == 0)
    //                    {
    //                        using (galadbEntities tctx = new galadbEntities())
    //                        {
    //                            DEMANDE laDem = tctx.DEMANDE.FirstOrDefault(t => t.NUMDEM == LaDemande.LaDemande.NUMDEM);
    //                            if (laDem != null)
    //                                DemandeID = laDem.PK_ID + "." + LaDemande.LaDemande.NUMDEM;
    //                        };
    //                    }
    //                    else
    //                        DemandeID = LaDemande.LaDemande.PK_ID + "." + LaDemande.LaDemande.NUMDEM;

    //                }
    //            }
    //            catch (Exception ex)
    //            {

    //                throw ex;
    //            }

    //        };
    //        return DemandeID;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception(ex.Message);
    //    }
    //}

    public List<CsEvenement> RetourneEvenement(int fk_idcentre, string centre, string client, string Ordre)
    {
        //cmd.CommandText = "SPX_GUI_RETOURNE_EVENEMENT";
        try
        {
            DataTable dt = Galatee.Entity.Model.FraudeProcedure.RetourneEvenement(fk_idcentre, centre, client, Ordre);
            return Entities.GetEntityListFromQuery<CsEvenement>(dt);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public List<CsEvenement> ConsommationByPeriodeMois(CsDemandeFraude laDemande, int mois, string periode)
    {
        cn = new SqlConnection(ConnectionString);

        cmd = new SqlCommand();
        cmd.Connection = cn;
        cmd.CommandTimeout = 180;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "SPX_FRD_CONSOMMATIONPERIODE";

        cmd.Parameters.Add("@Client", SqlDbType.VarChar, 20).Value = laDemande.ClientFraude.Client;
        cmd.Parameters.Add("@FK_IDCENTRE", SqlDbType.VarChar, 8).Value = laDemande.ClientFraude.FK_IDCENTRE;
        cmd.Parameters.Add("@Centre", SqlDbType.VarChar, 63).Value = laDemande.ClientFraude.Centre;
        cmd.Parameters.Add("@Ordre", SqlDbType.VarChar, 2).Value = laDemande.ClientFraude.Ordre;
        cmd.Parameters.Add("@Mois", SqlDbType.Int).Value = mois;
        cmd.Parameters.Add("@Periode", SqlDbType.VarChar, 6).Value = periode;

        DBBase.SetDBNullParametre(cmd.Parameters);
        try
        {
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            List<CsEvenement> evenementFraude = new List<CsEvenement>();
            while (reader.Read())
            {
                CsEvenement c = new CsEvenement();
                c.CONSO = (Convert.IsDBNull(reader["CONSO"])) ? 0 : (int)reader["CONSO"];
                //c.VolumeCalcule = (Convert.IsDBNull(reader["CONSOTOTAL"])) ? 0 : (int)reader["CONSOTOTAL"];
                c.PERIODE = (Convert.IsDBNull(reader["PERIODE"])) ? String.Empty : (String)reader["PERIODE"];
                evenementFraude.Add(c);
            }
            return evenementFraude;
            //DataTable dt = new DataTable();
            //if (reader.Read())
            //    dt.Load(reader);

            //return dt;

        }
        catch (Exception ex)
        {
            throw new Exception(cmd.CommandText + ":" + ex.Message);
        }
        finally
        {
            if (cn.State == ConnectionState.Open)
                cn.Close(); // Fermeture de la connection 
            cmd.Dispose();
        }
    }
 
        #region Fraude Mme KOUASSI

            public void AjouterDocumentScannes(List<ObjDOCUMENTSCANNE> ObjDoc, int DemandeId)
            {
                try
                {
                    if (ObjDoc != null && ObjDoc.Count != 0)
                    {
                        foreach (ObjDOCUMENTSCANNE item in ObjDoc.Where(y => y.CONTENU != null))
                        {
                            item.FK_IDDEMANDE = DemandeId;  //Convert.ToInt32(DemandeId);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        public void InsertOrUpdateDocumentScane(ObjDOCUMENTSCANNE leDocument, SqlCommand cmds)
        {
            cmds.CommandTimeout = 360;
            cmds.CommandType = CommandType.StoredProcedure;
            cmds.CommandText = "SPX_ACC_INSERTORUPDATE_DOCSCANNE";
            if (cmds.Parameters != null && cmds.Parameters.Count != 0) cmds.Parameters.Clear();

            cmds.Parameters.Add("@PK_ID", SqlDbType.UniqueIdentifier).Value = leDocument.PK_ID;
            cmds.Parameters.Add("@NOMDOCUMENT", SqlDbType.VarChar, 127).Value = leDocument.NOMDOCUMENT;
            cmds.Parameters.Add("@CONTENU", SqlDbType.VarBinary, int.MaxValue).Value = leDocument.CONTENU;
            cmds.Parameters.Add("@USERCREATION", SqlDbType.VarChar, 6).Value = leDocument.USERCREATION;
            cmds.Parameters.Add("@USERMODIFICATION", SqlDbType.VarChar, 6).Value = leDocument.USERMODIFICATION;
            cmds.Parameters.Add("@FK_IDDEMANDE", SqlDbType.Int).Value = leDocument.FK_IDDEMANDE;
            cmds.Parameters.Add("@FK_IDTYPEDOCUMENT", SqlDbType.Int).Value = leDocument.FK_IDTYPEDOCUMENT;
            
            DBBase.SetDBNullParametre(cmds.Parameters);

            try
            {
                if (cmds.Connection.State == ConnectionState.Closed)
                    cmds.Connection.Open();
                cmds.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                throw new Exception(cmds.CommandText + ":" + ex.Message);
            }
        }

        List<CsMoyenDenomciation> LstMoyenDenonc = new List<CsMoyenDenomciation>();

        public List<CsMoyenDenomciation> SelectAllMoyenDenonciation()
        {
            cn = new SqlConnection(ConnectString);

            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandTimeout = 180;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SPX_FRD_SELECT_MOYENDENONCIATION";

            DBBase.SetDBNullParametre(cmd.Parameters);
            try
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                return Entities.GetEntityListFromQuery<CsMoyenDenomciation>(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(cmd.CommandText + ":" + ex.Message);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close(); // Fermeture de la connection 
                cmd.Dispose();
            }
        }
        public CsFraude  SelectFraude(string numerodemande,int ? Fk_iddemande)
        {
            cn = new SqlConnection(ConnectString);

            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandTimeout = 180;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SPX_FRD_SELECTFRAUDE";
            cmd.Parameters.Add("@IDDEMANDE", SqlDbType.Int ).Value = Fk_iddemande;
            cmd.Parameters.Add("@NUMDEM", SqlDbType.VarChar ,20 ).Value = numerodemande;
            DBBase.SetDBNullParametre(cmd.Parameters);
            try
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                return Entities.GetEntityFromQuery<CsFraude>(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(cmd.CommandText + ":" + ex.Message);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close(); // Fermeture de la connection 
                cmd.Dispose();
            }
        }
        public CsDenonciateur  SelectDenonciateur(string numerodemande, int? Fk_iddemande)
        {
            cn = new SqlConnection(ConnectString);

            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandTimeout = 180;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SPX_FRD_SELECTDENONCIATEUR";
            cmd.Parameters.Add("@IDDEMANDE", SqlDbType.Int).Value = Fk_iddemande;
            cmd.Parameters.Add("@NUMDEM", SqlDbType.VarChar, 20).Value = numerodemande;
            DBBase.SetDBNullParametre(cmd.Parameters);
            try
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                return Entities.GetEntityFromQuery<CsDenonciateur >(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(cmd.CommandText + ":" + ex.Message);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close(); // Fermeture de la connection 
                cmd.Dispose();
            }
        }
        public CsClientFraude SelectClientFraude(string numerodemande, int? Fk_iddemande)
        {
            cn = new SqlConnection(ConnectString);

            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandTimeout = 180;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SPX_FRD_SELECTCLIENTFRAUDE";
            cmd.Parameters.Add("@IDDEMANDE", SqlDbType.Int).Value = Fk_iddemande;
            cmd.Parameters.Add("@NUMDEM", SqlDbType.VarChar, 20).Value = numerodemande;
            DBBase.SetDBNullParametre(cmd.Parameters);
            try
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                return Entities.GetEntityFromQuery<CsClientFraude>(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(cmd.CommandText + ":" + ex.Message);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close(); // Fermeture de la connection 
                cmd.Dispose();
            }
        }
        public CsCompteurFraude SelectCompteurFraude(string numerodemande, int? Fk_iddemande)
        {
            cn = new SqlConnection(ConnectString);

            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandTimeout = 180;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SPX_FRD_SELECTCOMPTERFRAUDE";
            cmd.Parameters.Add("@IDDEMANDE", SqlDbType.Int).Value = Fk_iddemande;
            cmd.Parameters.Add("@NUMDEM", SqlDbType.VarChar, 20).Value = numerodemande;
            DBBase.SetDBNullParametre(cmd.Parameters);
            try
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                return Entities.GetEntityFromQuery<CsCompteurFraude>(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(cmd.CommandText + ":" + ex.Message);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close(); // Fermeture de la connection 
                cmd.Dispose();
            }
        }

        public CsControle SelectControleFraude(string fiche)
        {
            cn = new SqlConnection(ConnectString);

            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandTimeout = 1800;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SPX_FRD_SELECT_CONTROLE_BYFICHE";
            cmd.Parameters.Add("@FICHE", SqlDbType.VarChar, 16).Value = fiche;
            DBBase.SetDBNullParametre(cmd.Parameters);
            try
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                return Entities.GetEntityFromQuery<CsControle>(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(cmd.CommandText + ":" + ex.Message);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close(); // Fermeture de la connection 
                cmd.Dispose();
            }
        }


        public CsControle SelectControleFraude(string numerodemande, int? Fk_iddemande)
        {
            cn = new SqlConnection(ConnectString);

            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandTimeout = 180;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SPX_FRD_SELECT_CONTROLE";
            cmd.Parameters.Add("@IDDEMANDE", SqlDbType.Int).Value = Fk_iddemande;
            cmd.Parameters.Add("@NUMDEM", SqlDbType.VarChar, 20).Value = numerodemande;
            DBBase.SetDBNullParametre(cmd.Parameters);
            try
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                return Entities.GetEntityFromQuery<CsControle>(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(cmd.CommandText + ":" + ex.Message);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close(); // Fermeture de la connection 
                cmd.Dispose();
            }
        }



        public List<CsAnomaliesFraude> SelectAnomaliesFraude(string numerodemande, int? Fk_iddemande)
        {
            cn = new SqlConnection(ConnectString);

            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandTimeout = 180;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SPX_FRD_SELECT_ANOMALIES";
            cmd.Parameters.Add("@IDDEMANDE", SqlDbType.Int).Value = Fk_iddemande;
            cmd.Parameters.Add("@NUMDEM", SqlDbType.VarChar, 20).Value = numerodemande;
            DBBase.SetDBNullParametre(cmd.Parameters);
            try
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                return Entities.GetEntityListFromQuery<CsAnomaliesFraude>(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(cmd.CommandText + ":" + ex.Message);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close(); // Fermeture de la connection 
                cmd.Dispose();
            }
        }




        //public CsControleur SelectControleurFraude(string numerodemande, int? Fk_iddemande)
        public List<CsControleur> SelectControleurFraude(string numerodemande, int? Fk_iddemande)
        {
            cn = new SqlConnection(ConnectString);

            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandTimeout = 180;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SPX_FRD_SELECT_CONTROLEUR";
            cmd.Parameters.Add("@IDDEMANDE", SqlDbType.Int).Value = Fk_iddemande;
            cmd.Parameters.Add("@NUMDEM", SqlDbType.VarChar, 20).Value = numerodemande;
            DBBase.SetDBNullParametre(cmd.Parameters);
            try
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                //return Entities.GetEntityFromQuery<CsControleur>(dt);
                return Entities.GetEntityListFromQuery<CsControleur>(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(cmd.CommandText + ":" + ex.Message);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close(); // Fermeture de la connection 
                cmd.Dispose();
            }
        }
        public List<CsAppareilRecenseFrd> SelectAppareilFraude(string numerodemande, int? Fk_iddemande)
        {
            cn = new SqlConnection(ConnectString);

            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandTimeout = 180;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SPX_FRD_SELECT_APPAREILRECENSER";
            cmd.Parameters.Add("@IDDEMANDE", SqlDbType.Int).Value = Fk_iddemande;
            cmd.Parameters.Add("@NUMDEM", SqlDbType.VarChar, 20).Value = numerodemande;
            DBBase.SetDBNullParametre(cmd.Parameters);
            try
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                return Entities.GetEntityListFromQuery<CsAppareilRecenseFrd>(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(cmd.CommandText + ":" + ex.Message);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close(); // Fermeture de la connection 
                cmd.Dispose();
            }
        }
        public List<CsAppareilUtiliserFrd> SelectAppareilUtiliserFraude(string numerodemande, int? Fk_iddemande)
        {
            cn = new SqlConnection(ConnectString);

            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandTimeout = 180;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SPX_FRD_SELECT_APAREIL_UTILISE";
            cmd.Parameters.Add("@IDDEMANDE", SqlDbType.Int).Value = Fk_iddemande;
            cmd.Parameters.Add("@NUMDEM", SqlDbType.VarChar, 20).Value = numerodemande;
            DBBase.SetDBNullParametre(cmd.Parameters);
            try
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                return Entities.GetEntityListFromQuery<CsAppareilUtiliserFrd>(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(cmd.CommandText + ":" + ex.Message);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close(); // Fermeture de la connection 
                cmd.Dispose();
            }
        }
        public CsAuditionFraude SelectAuditionFraude(string numerodemande, int? Fk_iddemande)
        {
            cn = new SqlConnection(ConnectString);

            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandTimeout = 180;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SPX_FRD_SELECT_AUDITION";
            cmd.Parameters.Add("@IDDEMANDE", SqlDbType.Int).Value = Fk_iddemande;
            cmd.Parameters.Add("@NUMDEM", SqlDbType.VarChar, 20).Value = numerodemande;
            DBBase.SetDBNullParametre(cmd.Parameters);
            try
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                return Entities.GetEntityFromQuery<CsAuditionFraude>(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(cmd.CommandText + ":" + ex.Message);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close(); // Fermeture de la connection 
                cmd.Dispose();
            }
        }
        public CsConsommationFrd SelectConsommatioFraude(string numerodemande, int? Fk_iddemande)
        {
            cn = new SqlConnection(ConnectString);

            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandTimeout = 180;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SPX_FRD_SELECT_CONSOMMATION";
            cmd.Parameters.Add("@IDDEMANDE", SqlDbType.Int).Value = Fk_iddemande;
            cmd.Parameters.Add("@NUMDEM", SqlDbType.VarChar, 20).Value = numerodemande;
            DBBase.SetDBNullParametre(cmd.Parameters);
            try
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                return Entities.GetEntityFromQuery<CsConsommationFrd>(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(cmd.CommandText + ":" + ex.Message);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close(); // Fermeture de la connection 
                cmd.Dispose();
            }
        }
        public List<CsRegularisation> SelectRegularisationFraude(int? Fk_idPhase)
        {
            cn = new SqlConnection(ConnectString);

            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandTimeout = 180;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SPX_FRD_SELECTCLIENTFRAUDE";
            cmd.Parameters.Add("@FK_IDFRAUDE", SqlDbType.Int).Value = Fk_idPhase;
            DBBase.SetDBNullParametre(cmd.Parameters);
            try
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                return Entities.GetEntityListFromQuery<CsRegularisation>(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(cmd.CommandText + ":" + ex.Message);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close(); // Fermeture de la connection 
                cmd.Dispose();
            }
        }
        public List<CsRegularisation> SelectRegularisation(int? Fk_idPhase)
        {
            cn = new SqlConnection(ConnectString);

            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandTimeout = 180;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SPX_FRD_SELECT_REGULARISATION";
            cmd.Parameters.Add("@FK_IDPHASE", SqlDbType.Int).Value = Fk_idPhase;

            DBBase.SetDBNullParametre(cmd.Parameters);
            try
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                return Entities.GetEntityListFromQuery<CsRegularisation>(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(cmd.CommandText + ":" + ex.Message);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close(); // Fermeture de la connection 
                cmd.Dispose();
            }
        }
        public List<CsPrestastionFrd> SelectPrestationFraude()
        {
            cn = new SqlConnection(ConnectString);

            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandTimeout = 180;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SPX_FRD_SELECT_PRESTATION";
            DBBase.SetDBNullParametre(cmd.Parameters);
            try
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                return Entities.GetEntityListFromQuery<CsPrestastionFrd>(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(cmd.CommandText + ":" + ex.Message);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close(); // Fermeture de la connection 
                cmd.Dispose();
            }
        }
        public List<CsPrestationRemboursable > SelectPrestationRemboursable()
        {
            cn = new SqlConnection(ConnectString);

            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandTimeout = 180;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SPX_FRD_SELECT_PRESTATIONREMBOURSABLE";
            DBBase.SetDBNullParametre(cmd.Parameters);
            try
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                return Entities.GetEntityListFromQuery<CsPrestationRemboursable>(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(cmd.CommandText + ":" + ex.Message);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close(); // Fermeture de la connection 
                cmd.Dispose();
            }
        }

        public List<CsDETAILparTRANCHE> SelectDetailTranche(int Fk_idfraude)
        {
            cn = new SqlConnection(ConnectString);

            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandTimeout = 180;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SPX_FRD_SELECT_DETAILTRANCHE";
            if (cmd.Parameters != null && cmd.Parameters.Count != 0) cmd.Parameters.Clear();
            cmd.Parameters.Add("@FK_IDFRAUDE", SqlDbType.Int).Value = Fk_idfraude;

            DBBase.SetDBNullParametre(cmd.Parameters);
            try
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                return Entities.GetEntityListFromQuery<CsDETAILparTRANCHE>(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(cmd.CommandText + ":" + ex.Message);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close(); // Fermeture de la connection 
                cmd.Dispose();
            }
        }
        public List<CsDETAILparPRESTATIONREMBOURSABLE> SelectDetailPrestationRemboursable(int Fk_idfraude)
        {
            cn = new SqlConnection(ConnectString);

            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandTimeout = 180;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SPX_FRD_SELECT_DETAILPRESTATIONREMBOURSABLE";
            cmd.Parameters.Add("@FK_IDFRAUDE", SqlDbType.Int).Value = Fk_idfraude;
            DBBase.SetDBNullParametre(cmd.Parameters);
            try
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                return Entities.GetEntityListFromQuery<CsDETAILparPRESTATIONREMBOURSABLE>(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(cmd.CommandText + ":" + ex.Message);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close(); // Fermeture de la connection 
                cmd.Dispose();
            }
        }
        public List<CsDetailParPresentationEdm> SelectDetailPrestationEdm(int Fk_idfraude)
        {
            cn = new SqlConnection(ConnectString);

            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandTimeout = 180;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SPX_FRD_SELECT_DETAILPRESTATIONREMBOURSABLE";
            cmd.Parameters.Add("@FK_IDFRAUDE", SqlDbType.Int).Value = Fk_idfraude;
            DBBase.SetDBNullParametre(cmd.Parameters);
            try
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                return Entities.GetEntityListFromQuery<CsDetailParPresentationEdm>(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(cmd.CommandText + ":" + ex.Message);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close(); // Fermeture de la connection 
                cmd.Dispose();
            }
        }
        public List<CsDETAILparREGULARISATION> SelectDetailRegarisation(int Fk_idfraude)
        {
            cn = new SqlConnection(ConnectString);

            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandTimeout = 180;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SPX_FRD_SELECT_DETAILparREGULARISATION";
            cmd.Parameters.Add("@FK_IDFRAUDE", SqlDbType.Int).Value = Fk_idfraude;
            DBBase.SetDBNullParametre(cmd.Parameters);
            try
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                return Entities.GetEntityListFromQuery<CsDETAILparREGULARISATION>(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(cmd.CommandText + ":" + ex.Message);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close(); // Fermeture de la connection 
                cmd.Dispose();
            }
        }


        public void InsertDENONCIATEUR(CsDenonciateur Denonciateur, SqlCommand cmds)
        {

            //SqlCommand cmds = new SqlCommand();
            //cmds = DBBase.InitTransaction(ConnectString);
            cmds.CommandTimeout = 360;
            cmds.CommandType = CommandType.StoredProcedure;
            cmds.CommandText = "SPX_FRD_INSERT_DENONCIATEUR";
            if (cmds.Parameters != null && cmds.Parameters.Count != 0) cmds.Parameters.Clear();
            cmds.Parameters.Add("@Nom", SqlDbType.VarChar, 63).Value = Denonciateur.Nom;
            cmds.Parameters.Add("@Localisation", SqlDbType.VarChar, 100).Value = Denonciateur.Localisation;
            cmds.Parameters.Add("@Contact", SqlDbType.VarChar, 63).Value = Denonciateur.Contact;
            cmds.Parameters.Add("@LienAvecAbonne", SqlDbType.VarChar, 63).Value = Denonciateur.LienAvecAbonne;
            cmds.Parameters.Add("@DateDenonciation", SqlDbType.DateTime).Value = Denonciateur.DateDenonciation;
            cmds.Parameters.Add("@FK_IDLOCALISATION", SqlDbType.Int).Value = Denonciateur.FK_IDLOCALISATION;
            cmds.Parameters.Add("@FK_IDMOYENDENONCIATION", SqlDbType.Int).Value = Denonciateur.FK_IDMOYENDENONCIATION;

            SqlParameter outResult = new SqlParameter("@PK_ID", SqlDbType.VarChar, int.MaxValue) { Direction = ParameterDirection.Output };
            outResult.Value = Denonciateur.PK_ID;
            cmds.Parameters.Add(outResult);
            DBBase.SetDBNullParametre(cmds.Parameters);

            try
            {
                string IdDenonciat = string.Empty;
                if (cmds.Connection.State == ConnectionState.Closed)
                    cmds.Connection.Open();
                cmds.ExecuteNonQuery();
                IdDenonciat = outResult.Value != null ? outResult.Value.ToString() : "1";
                Denonciateur.PK_ID = int.Parse(IdDenonciat);
            }
            catch (Exception ex)
            {
                throw new Exception(cmds.CommandText + ":" + ex.Message);
            }
        }
        public void InsertOrUpdateCLIENTFRAUDE(CsClientFraude ClientFraude, SqlCommand cmds)
        {

            cmds.CommandTimeout = 360;
            cmds.CommandType = CommandType.StoredProcedure;
            cmds.CommandText = "SPX_FRD_INSERTorUPDATE_CLIENTFRAUDE";
            if (cmds.Parameters != null && cmds.Parameters.Count != 0) cmds.Parameters.Clear();
            cmds.Parameters.Add("@FK_IDSITE", SqlDbType.Int).Value = ClientFraude.FK_IDSITE;
            cmds.Parameters.Add("@FK_IDCENTRE", SqlDbType.Int).Value = ClientFraude.FK_IDCENTRE;
            cmds.Parameters.Add("@Centre", SqlDbType.VarChar, 63).Value = ClientFraude.Centre;
            cmds.Parameters.Add("@Client", SqlDbType.VarChar, 20).Value = ClientFraude.Client;
            cmds.Parameters.Add("@Ordre", SqlDbType.VarChar, 2).Value = ClientFraude.Ordre;
            cmds.Parameters.Add("@NUMEROABONNE", SqlDbType.VarChar, 31).Value = ClientFraude.NUMEROABONNE;
            cmds.Parameters.Add("@Nomabon", SqlDbType.VarChar, 63).Value = ClientFraude.Nomabon;
            cmds.Parameters.Add("@Email", SqlDbType.VarChar, 63).Value = ClientFraude.Email;
            cmds.Parameters.Add("@Telephone", SqlDbType.VarChar, 31).Value = ClientFraude.Telephone;
            cmds.Parameters.Add("@Commune", SqlDbType.VarChar, 30).Value = ClientFraude.Commune;
            cmds.Parameters.Add("@Quartier", SqlDbType.VarChar, 31).Value = ClientFraude.Quartier;
            cmds.Parameters.Add("@Rue", SqlDbType.VarChar, 30).Value = ClientFraude.Rue;
            cmds.Parameters.Add("@Porte", SqlDbType.VarChar, 15).Value = ClientFraude.Porte;
            cmds.Parameters.Add("@Tournee", SqlDbType.VarChar, 15).Value = ClientFraude.Tournee;
            cmds.Parameters.Add("@OrdreTournee", SqlDbType.VarChar, 15).Value = ClientFraude.OrdreTournee;
            cmds.Parameters.Add("@Secteur", SqlDbType.VarChar, 30).Value = ClientFraude.Secteur;
            cmds.Parameters.Add("@ContratAbonnement", SqlDbType.VarChar, 63).Value = ClientFraude.ContratAbonnement;
            cmds.Parameters.Add("@DateContratAbonnement", SqlDbType.DateTime).Value = ClientFraude.DateContratAbonnement;
            cmds.Parameters.Add("@ContratBranchement", SqlDbType.VarChar, 63).Value = ClientFraude.ContratBranchement;
            cmds.Parameters.Add("@DateContratBranchement", SqlDbType.DateTime).Value = ClientFraude.DateContratBranchement;
            cmds.Parameters.Add("@PuissanceSouscrite", SqlDbType.Decimal).Value = ClientFraude.PuissanceSouscrite;
            cmds.Parameters.Add("@PuissanceInstallee", SqlDbType.Decimal).Value = ClientFraude.PuissanceInstallee;

            cmds.Parameters.Add("@NumPieceIdentite", SqlDbType.VarChar, 50).Value = ClientFraude.NumPieceIdentite;
            cmds.Parameters.Add("@FK_IDCOMMUNE", SqlDbType.Int).Value = ClientFraude.FK_IDCOMMUNE;
            cmds.Parameters.Add("@FK_IDQUARTIER", SqlDbType.Int).Value = ClientFraude.FK_IDQUARTIER;
            cmds.Parameters.Add("@FK_SECTEUR", SqlDbType.Int).Value = ClientFraude.FK_SECTEUR;
            cmds.Parameters.Add("@FK_RUE", SqlDbType.Int).Value = ClientFraude.FK_RUE;
            cmds.Parameters.Add("@FK_IDABON", SqlDbType.Int).Value = ClientFraude.FK_IDABON;//Convert.ToInt32(ClientFraude.Client);
            cmds.Parameters.Add("@FK_IDDEMANDE", SqlDbType.Int).Value = ClientFraude.FK_IDDEMANDE ;//Convert.ToInt32(ClientFraude.Client);
            cmds.Parameters.Add("@FK_IDTYPECLIENTFRAUDE", SqlDbType.Int).Value = ClientFraude.FK_IDTYPECLIENTFRAUDE;//Convert.ToInt32(ClientFraude.Client);
            cmds.Parameters.Add("@TARIF", SqlDbType.VarChar, 5).Value = ClientFraude.TYPETARIF;
            cmds.Parameters.Add("@PDLVoisin", SqlDbType.VarChar, 20).Value = ClientFraude.PDLVoisin;

            
            SqlParameter outResult = new SqlParameter("@PK_ID", SqlDbType.VarChar, int.MaxValue) { Direction = ParameterDirection.Output };
            outResult.Value = ClientFraude.PK_ID;
            cmds.Parameters.Add(outResult);
            DBBase.SetDBNullParametre(cmds.Parameters);

            try
            {
                string IdClientF = string.Empty;
                if (cmds.Connection.State == ConnectionState.Closed)
                    cmds.Connection.Open();
                cmds.ExecuteNonQuery();
                IdClientF = outResult.Value != null ? outResult.Value.ToString() : "1";

                ClientFraude.PK_ID = int.Parse(IdClientF);
            }
            catch (Exception ex)
            {
                throw new Exception(cmds.CommandText + ":" + ex.Message);
            }
        }
        public void InsertOrUpdateCOMPTEUR(CsCompteurFraude CompteurFraude, SqlCommand cmds)
        {

            cmds.CommandTimeout = 360;
            cmds.CommandType = CommandType.StoredProcedure;
            cmds.CommandText = "SPX_FRD_INSERTorUPDATE_COMPTEUR";
            if (cmds.Parameters != null && cmds.Parameters.Count != 0) cmds.Parameters.Clear();
            cmds.Parameters.Add("@NumeroCompteur", SqlDbType.VarChar, 31).Value = CompteurFraude.NumeroCompteur;
            cmds.Parameters.Add("@IndexCompteur", SqlDbType.Int).Value = CompteurFraude.IndexCompteur;
            cmds.Parameters.Add("@RefPlombCompteur", SqlDbType.VarChar, 63).Value = CompteurFraude.RefPlombCompteur;
            cmds.Parameters.Add("@NumeroPince", SqlDbType.VarChar, 20).Value = CompteurFraude.NumeroPince;
            cmds.Parameters.Add("@CertificatPlombage", SqlDbType.VarChar, 2).Value = CompteurFraude.CertificatPlombage;
            cmds.Parameters.Add("@RefPlombCoffretFusible", SqlDbType.VarChar, 31).Value = CompteurFraude.RefPlombCoffretFusible;
            cmds.Parameters.Add("@RefPlombCoffretSecurite", SqlDbType.VarChar, 63).Value = CompteurFraude.RefPlombCoffretSecurite;
            cmds.Parameters.Add("@RefPlombCacheBorne", SqlDbType.VarChar, 63).Value = CompteurFraude.RefPlombCacheBorne;
            cmds.Parameters.Add("@Bordereau", SqlDbType.VarChar, 63).Value = CompteurFraude.Bordereau;
            cmds.Parameters.Add("@IsEcartIndex", SqlDbType.Bit).Value = CompteurFraude.IsEcartIndex;
            cmds.Parameters.Add("@FK_IDCLIENTFRAUDE", SqlDbType.Int).Value = CompteurFraude.FK_IDCLIENTFRAUDE;
            cmds.Parameters.Add("@FK_IDCONTROLE", SqlDbType.Int).Value = CompteurFraude.FK_IDCONTROLE;
            cmds.Parameters.Add("@FK_IDPRODUIT", SqlDbType.Int).Value = CompteurFraude.FK_IDPRODUIT;
            cmds.Parameters.Add("@FK_IDMARQUECOMPTEUR", SqlDbType.Int).Value = CompteurFraude.FK_IDMARQUECOMPTEUR;
            cmds.Parameters.Add("@FK_IDTYPECOMPTEUR", SqlDbType.Int).Value = CompteurFraude.FK_IDTYPECOMPTEUR;
            cmds.Parameters.Add("@FK_IDANOMALIECOMPTEUR", SqlDbType.Int).Value = CompteurFraude.FK_IDANOMALIECOMPTEUR;
            cmds.Parameters.Add("@FK_IDANOMALIECACHEBORNE", SqlDbType.Int).Value = CompteurFraude.FK_IDANOMALIECACHEBORNE;
            cmds.Parameters.Add("@FK_IDANOMALIEBRANCHEMENT", SqlDbType.Int).Value = CompteurFraude.FK_IDANOMALIEBRANCHEMENT;
            cmds.Parameters.Add("@FK_IDPHASECOMPTEUR", SqlDbType.Int).Value = CompteurFraude.FK_IDPHASECOMPTEUR;
            cmds.Parameters.Add("@FK_IDCALIBRECOMPTEUR", SqlDbType.Int).Value = CompteurFraude.FK_IDCALIBRECOMPTEUR;
            cmds.Parameters.Add("@FK_IDREGLAGE", SqlDbType.Int).Value = CompteurFraude.FK_IDREGLAGE;
            cmds.Parameters.Add("@FK_IDACTIONSURCOMPTEUR", SqlDbType.Int).Value = CompteurFraude.FK_IDACTIONSURCOMPTEUR;
            cmds.Parameters.Add("@FK_IDUSAGEPRODUIT", SqlDbType.Int).Value = CompteurFraude.FK_IDUSAGEPRODUIT;

            cmds.Parameters.Add("@FK_IDTYPEDISJONCTEUR", SqlDbType.VarChar, 50).Value = CompteurFraude.FK_IDTYPEDISJONCTEUR;
            cmds.Parameters.Add("@FK_IDMARQUEDISJONCTEUR", SqlDbType.Int).Value = CompteurFraude.FK_IDMARQUEDISJONCTEUR;
            cmds.Parameters.Add("@PRODUIT", SqlDbType.VarChar, 2).Value = CompteurFraude.PRODUIT;//Convert.ToInt32(ClientFraude.Client);
            cmds.Parameters.Add("@TYPECOMPTEUR", SqlDbType.VarChar, 1).Value = CompteurFraude.TYPECOMPTEUR;//Convert.ToInt32(ClientFraude.Client);
            cmds.Parameters.Add("@MARQUE", SqlDbType.VarChar, 2).Value = CompteurFraude.MARQUE;//Convert.ToInt32(ClientFraude.Client);
            cmds.Parameters.Add("@USAGEPRODUIT", SqlDbType.VarChar, 3).Value = CompteurFraude.USAGEPRODUIT;//Convert.ToInt32(ClientFraude.Client);
            cmds.Parameters.Add("@FK_IDFRAUDE", SqlDbType.Int).Value = CompteurFraude.FK_IDFRAUDE;
            DBBase.SetDBNullParametre(cmds.Parameters);

            try
            {
                string IdClientF = string.Empty;
                if (cmds.Connection.State == ConnectionState.Closed)
                    cmds.Connection.Open();
                cmds.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(cmds.CommandText + ":" + ex.Message);
            }
        }
        public void InsertOrUpdateCONTROLE(CsControle ControleFraude, SqlCommand cmds)
        {

            cmds.CommandTimeout = 360;
            cmds.CommandType = CommandType.StoredProcedure;
            cmds.CommandText = "SPX_FRD_INSERTorUPDATE_CONTROLE";
            if (cmds.Parameters != null && cmds.Parameters.Count != 0) cmds.Parameters.Clear();
            cmds.Parameters.Add("@FicheControle", SqlDbType.VarChar, 31).Value = ControleFraude.FicheControle;
            cmds.Parameters.Add("@Ordonnateur", SqlDbType.VarChar, 128).Value = ControleFraude.Ordonnateur;
            cmds.Parameters.Add("@Convocation", SqlDbType.VarChar, 20).Value = ControleFraude.Convocation;
            cmds.Parameters.Add("@NomExpert", SqlDbType.VarChar, 63).Value = ControleFraude.NomExpert;
            cmds.Parameters.Add("@DateControle", SqlDbType.DateTime, 20).Value = ControleFraude.DateControle;
            cmds.Parameters.Add("@DescriptionIrregulariteEtObservations", SqlDbType.VarChar, 31).Value = ControleFraude.DescriptionIrregulariteEtObservations;
            cmds.Parameters.Add("@IsAbonneOuRepresentantPresent", SqlDbType.Bit).Value = ControleFraude.IsAbonneOuRepresentantPresent;
            cmds.Parameters.Add("@CourantAdmissibleParCable", SqlDbType.Int).Value = ControleFraude.CourantAdmissibleParCable;
            cmds.Parameters.Add("@IsFraudeAveree", SqlDbType.Bit).Value = ControleFraude.IsFraudeAveree;
            cmds.Parameters.Add("@IsConvocationRemise", SqlDbType.Bit).Value = ControleFraude.IsConvocationRemise;
            cmds.Parameters.Add("@CommissariatPolicePresent", SqlDbType.VarChar, 63).Value = ControleFraude.CommissariatPolicePresent;
            cmds.Parameters.Add("@IsAnomalieReconnue", SqlDbType.Bit).Value = ControleFraude.IsAnomalieReconnue;
            cmds.Parameters.Add("@OrdreTraitement", SqlDbType.TinyInt).Value = ControleFraude.OrdreTraitement;
            cmds.Parameters.Add("@FK_IDCLIENTFRAUDE", SqlDbType.Int).Value = ControleFraude.FK_IDCLIENTFRAUDE;
            cmds.Parameters.Add("@FK_IDFRAUDE", SqlDbType.Int).Value = ControleFraude.FK_IDFRAUDE;
            cmds.Parameters.Add("@FK_IDQUALITEEXPERT", SqlDbType.Int).Value = ControleFraude.FK_IDQUALITEEXPERT;
            cmds.Parameters.Add("@FK_IDPROCESVERBALSCANNE", SqlDbType.UniqueIdentifier).Value = ControleFraude.FK_IDPROCESVERBALSCANNE;
            //cmds.Parameters.Add("@FK_IDCONTROLEUR1", SqlDbType.Int).Value = ControleFraude.FK_IDCONTROLEUR1;
            //cmds.Parameters.Add("@FK_IDCONTROLEUR2", SqlDbType.Int).Value = ControleFraude.FK_IDCONTROLEUR2;


            SqlParameter outResult = new SqlParameter("@PK_ID", SqlDbType.VarChar, int.MaxValue) { Direction = ParameterDirection.Output };
            outResult.Value = ControleFraude.PK_ID;
            cmds.Parameters.Add(outResult);

            DBBase.SetDBNullParametre(cmds.Parameters);

            try
            {
                string IdControle = string.Empty;
                if (cmds.Connection.State == ConnectionState.Closed)
                    cmds.Connection.Open();
                cmds.ExecuteNonQuery();

                IdControle = outResult.Value != null ? outResult.Value.ToString() : "1";
                if (ControleFraude.PK_ID == 0 && !string.IsNullOrEmpty(IdControle))
                    ControleFraude.PK_ID = int.Parse(IdControle);

            }
            catch (Exception ex)
            {
                throw new Exception(cmds.CommandText + ":" + ex.Message);
            }
        }



        public void DeleteANOMALIESFRAUDE(int idFraude, SqlCommand cmds)
        {

            cmds.CommandTimeout = 360;
            cmds.CommandType = CommandType.StoredProcedure;
            cmds.CommandText = "SPX_FRD_DELETE_ANOMALIES";
            if (cmds.Parameters != null && cmds.Parameters.Count != 0) cmds.Parameters.Clear();
            cmds.Parameters.Add("@FK_IDFRAUDE", SqlDbType.Int).Value = idFraude;
            DBBase.SetDBNullParametre(cmds.Parameters);

            try
            {
                if (cmds.Connection.State == ConnectionState.Closed)
                    cmds.Connection.Open();
                cmds.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(cmds.CommandText + ":" + ex.Message);
            }
        }



        public void InsertOrUpdateANOMALIESFRAUDE(CsAnomaliesFraude anomalie, SqlCommand cmds)
        {

            cmds.CommandTimeout = 360;
            cmds.CommandType = CommandType.StoredProcedure;
            cmds.CommandText = "SPX_FRD_INSERTorUPDATE_ANOMALIE";
            if (cmds.Parameters != null && cmds.Parameters.Count != 0) cmds.Parameters.Clear();
            cmds.Parameters.Add("@FK_IDANOMALIE", SqlDbType.Int).Value = anomalie.FK_IDANOMALIE;
            cmds.Parameters.Add("@FK_IDFRAUDE", SqlDbType.Int).Value = anomalie.FK_IDFRAUDE;
            cmds.Parameters.Add("@FicheControle", SqlDbType.VarChar, 20).Value = anomalie.FicheControle;
            cmds.Parameters.Add("@NOMBREFOYER", SqlDbType.Int).Value = anomalie.NOMBREFOYER;
            DBBase.SetDBNullParametre(cmds.Parameters);

            try
            {
                string IdClientF = string.Empty;
                if (cmds.Connection.State == ConnectionState.Closed)
                    cmds.Connection.Open();
                cmds.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(cmds.CommandText + ":" + ex.Message);
            }
        }

        public void DeleteCONTROLEUR(int idFraude, SqlCommand cmds)
        {

            cmds.CommandTimeout = 360;
            cmds.CommandType = CommandType.StoredProcedure;
            cmds.CommandText = "SPX_FRD_DELETE_CONTROLEUR";
            if (cmds.Parameters != null && cmds.Parameters.Count != 0) cmds.Parameters.Clear();
            cmds.Parameters.Add("@FK_IDFRAUDE", SqlDbType.Int).Value = idFraude;
            DBBase.SetDBNullParametre(cmds.Parameters);

            try
            {
                if (cmds.Connection.State == ConnectionState.Closed)
                    cmds.Connection.Open();
                cmds.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(cmds.CommandText + ":" + ex.Message);
            }
        }


        public void InsertOrUpdateCONTROLEUR(CsControleur ControleurFraude, SqlCommand cmds)
        {

            cmds.CommandTimeout = 360;
            cmds.CommandType = CommandType.StoredProcedure;
            cmds.CommandText = "SPX_FRD_INSERTorUPDATE_CONTROLEUR";
            if (cmds.Parameters != null && cmds.Parameters.Count != 0) cmds.Parameters.Clear();
            cmds.Parameters.Add("@FK_IDUSERCONTROLEUR", SqlDbType.Int).Value = ControleurFraude.FK_IDUSERCONTROLEUR;
            cmds.Parameters.Add("@IsChefEquipe", SqlDbType.Bit).Value = ControleurFraude.IsChefEquipe;
            cmds.Parameters.Add("@FK_IDFRAUDE", SqlDbType.Int).Value = ControleurFraude.FK_IDFRAUDE;
            cmds.Parameters.Add("@FicheControle", SqlDbType.VarChar, 20).Value = ControleurFraude.FicheControle;
            DBBase.SetDBNullParametre(cmds.Parameters);

            try
            {
                string IdClientF = string.Empty;
                if (cmds.Connection.State == ConnectionState.Closed)
                    cmds.Connection.Open();
                cmds.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(cmds.CommandText + ":" + ex.Message);
            }
        }


        public void InsertOrUpdateAUDITEUR(CsAuditionFraude AuditionFraude, SqlCommand cmds)
        {

            cmds.CommandTimeout = 360;
            cmds.CommandType = CommandType.StoredProcedure;
            cmds.CommandText = "SPX_FRD_INSERTorUPDATE_COMPTEUR";
            if (cmds.Parameters != null && cmds.Parameters.Count != 0) cmds.Parameters.Clear();
            cmds.Parameters.Add("@DateRendezVous", SqlDbType.DateTime).Value = AuditionFraude.DateRendezVous;
            cmds.Parameters.Add("@DateAudition", SqlDbType.DateTime).Value = AuditionFraude.DateAudition;
            cmds.Parameters.Add("@NomRepondant", SqlDbType.VarChar, 63).Value = AuditionFraude.NomRepondant;
            cmds.Parameters.Add("@QualiteRepondant", SqlDbType.VarChar, 63).Value = AuditionFraude.QualiteRepondant;
            cmds.Parameters.Add("@IsProprietaire", SqlDbType.Bit).Value = AuditionFraude.IsProprietaire;
            cmds.Parameters.Add("@IsMaisonHabitee", SqlDbType.Bit).Value = AuditionFraude.IsMaisonHabitee;
            cmds.Parameters.Add("@NombreHabitant", SqlDbType.Int).Value = AuditionFraude.NombreHabitant;
            cmds.Parameters.Add("@IsDejaDepanne", SqlDbType.Bit).Value = AuditionFraude.IsMaisonHabitee;
            cmds.Parameters.Add("@MotifDepannage", SqlDbType.VarChar, 63).Value = AuditionFraude.MotifDepannage;
            cmds.Parameters.Add("@IsDejaPenaliseSurCompteur", SqlDbType.Bit).Value = AuditionFraude.IsDejaPenaliseSurCompteur;
            cmds.Parameters.Add("@IsFacturePenaliteDejaRecue", SqlDbType.Bit).Value = AuditionFraude.IsFacturePenaliteDejaRecue;
            cmds.Parameters.Add("@IsDemandeVerificationDejaEmise", SqlDbType.Bit).Value = AuditionFraude.IsDemandeVerificationDejaEmise;
            cmds.Parameters.Add("@IsAccuseReceptionDemande", SqlDbType.Bit).Value = AuditionFraude.IsAccuseReceptionDemande;
            cmds.Parameters.Add("@IsCertificatPlombageRecu", SqlDbType.Bit).Value = AuditionFraude.IsCertificatPlombageRecu;
            cmds.Parameters.Add("@IsNewAppareilAcquis", SqlDbType.Bit).Value = AuditionFraude.IsNewAppareilAcquis;
            cmds.Parameters.Add("@FK_IDPROCESVERBALSCANNE", SqlDbType.UniqueIdentifier).Value = AuditionFraude.FK_IDPROCESVERBALSCANNE;
            cmds.Parameters.Add("@FK_IDFRAUDE", SqlDbType.Int).Value = AuditionFraude.FK_IDFRAUDE;
            DBBase.SetDBNullParametre(cmds.Parameters);

            try
            {
                string IdClientF = string.Empty;
                if (cmds.Connection.State == ConnectionState.Closed)
                    cmds.Connection.Open();
                cmds.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(cmds.CommandText + ":" + ex.Message);
            }
        }
        public void UpdateDENONCIATEUR(CsDenonciateur Denonciateur, SqlCommand cmds)
        {

            //SqlCommand cmds = new SqlCommand();
            //cmds = DBBase.InitTransaction(ConnectString);
            cmds.CommandTimeout = 360;
            cmds.CommandType = CommandType.StoredProcedure;
            cmds.CommandText = "SPX_FRD_UPDATE_DENONCIATEUR";
            if (cmds.Parameters != null && cmds.Parameters.Count != 0) cmds.Parameters.Clear();
            cmds.Parameters.Add("@PK_ID", SqlDbType.Int).Value = Denonciateur.PK_ID;
            cmds.Parameters.Add("@Nom", SqlDbType.VarChar, 63).Value = Denonciateur.Nom;
            cmds.Parameters.Add("@Localisation", SqlDbType.VarChar, 100).Value = Denonciateur.Localisation;
            cmds.Parameters.Add("@Contact", SqlDbType.VarChar, 63).Value = Denonciateur.Contact;
            cmds.Parameters.Add("@LienAvecAbonne", SqlDbType.VarChar, 63).Value = Denonciateur.LienAvecAbonne;
            cmds.Parameters.Add("@DateDenonciation", SqlDbType.DateTime).Value = Denonciateur.DateDenonciation;
            cmds.Parameters.Add("@FK_IDLOCALISATION", SqlDbType.Int).Value = Denonciateur.FK_IDLOCALISATION;
            cmds.Parameters.Add("@FK_IDMOYENDENONCIATION", SqlDbType.Int).Value = Denonciateur.FK_IDMOYENDENONCIATION;

            DBBase.SetDBNullParametre(cmds.Parameters);

            try
            {
                if (cmds.Connection.State == ConnectionState.Closed)
                    cmds.Connection.Open();
                cmds.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception(cmds.CommandText + ":" + ex.Message);
            }
        }
        public void InsertorUpdateAppareilRecense(List<CsAppareilRecenseFrd>  lstAppareilRecenseFraude, SqlCommand cmds)
        {
            foreach (CsAppareilRecenseFrd AppareilRecenseFraude in lstAppareilRecenseFraude)
            {
                cmds.CommandTimeout = 360;
                cmds.CommandType = CommandType.StoredProcedure;
                cmds.CommandText = "SPX_FRD_INSERTorUPDATE_APPAREILRECENSE";
                if (cmds.Parameters != null && cmds.Parameters.Count != 0) cmds.Parameters.Clear();
                cmds.Parameters.Add("@NOMBRE", SqlDbType.Int).Value = AppareilRecenseFraude.NOMBRE;
                cmds.Parameters.Add("@PUISSANCEUNITAIRE", SqlDbType.Int).Value = AppareilRecenseFraude.PUISSANCEUNITAIRE;
                cmds.Parameters.Add("@OBSERVATION", SqlDbType.VarChar, 255).Value = AppareilRecenseFraude.OBSERVATION;
                cmds.Parameters.Add("@FK_IDAPPAREIL", SqlDbType.Int).Value = AppareilRecenseFraude.FK_IDAPPAREIL;
                cmds.Parameters.Add("@FK_IDPRODUIT", SqlDbType.Int).Value = AppareilRecenseFraude.FK_IDPRODUIT;
                cmds.Parameters.Add("@CODEAPPAREIL", SqlDbType.Int).Value = AppareilRecenseFraude.CODEAPPAREIL;
                cmds.Parameters.Add("@FK_IDFRAUDE", SqlDbType.Int).Value = AppareilRecenseFraude.FK_IDFRAUDE;
                cmds.Parameters.Add("@FICHECONTROLE", SqlDbType.VarChar, 20).Value = AppareilRecenseFraude.FicheControle;
                DBBase.SetDBNullParametre(cmds.Parameters);

                try
                {
                    string IdFraude = string.Empty;
                    if (cmds.Connection.State == ConnectionState.Closed)
                        cmds.Connection.Open();
                    cmds.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(cmds.CommandText + ":" + ex.Message);
                }  
            }
           
        }
        public void InsertorUpdateAppareilUtlise(List<CsAppareilUtiliserFrd> lstAppareilUtliseFraude, SqlCommand cmds)
        {
            foreach (CsAppareilUtiliserFrd AppareiltiiseFraude in lstAppareilUtliseFraude)
            {
                cmds.CommandTimeout = 360;
                cmds.CommandType = CommandType.StoredProcedure;
                cmds.CommandText = "SPX_FRD_INSERTorUPDATE_APPAREILSUTILISE";
                if (cmds.Parameters != null && cmds.Parameters.Count != 0) cmds.Parameters.Clear();
                cmds.Parameters.Add("@EMPORTE", SqlDbType.Int).Value = AppareiltiiseFraude.EMPORTE;
                cmds.Parameters.Add("@RESTITUE", SqlDbType.Int).Value = AppareiltiiseFraude.RESTITUE;
                cmds.Parameters.Add("@FK_IDAPPAREIL", SqlDbType.Int).Value = AppareiltiiseFraude.FK_IDAPPAREIL;
                cmds.Parameters.Add("@FK_IDPRODUIT", SqlDbType.Int).Value = AppareiltiiseFraude.FK_IDPRODUIT;
                cmds.Parameters.Add("@CODEAPPAREIL", SqlDbType.Int).Value = AppareiltiiseFraude.CODEAPPAREIL;
                cmds.Parameters.Add("@FK_IDFRAUDE", SqlDbType.Int).Value = AppareiltiiseFraude.FK_IDFRAUDE;
                cmds.Parameters.Add("@FICHECONTROLE", SqlDbType.VarChar, 20).Value = AppareiltiiseFraude.FicheControle;
                DBBase.SetDBNullParametre(cmds.Parameters);

                try
                {
                    string IdFraude = string.Empty;
                    if (cmds.Connection.State == ConnectionState.Closed)
                        cmds.Connection.Open();
                    cmds.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(cmds.CommandText + ":" + ex.Message);
                }
            }

        }

        public void UpdateAppareilRestitue(List<CsAppareilUtiliserFrd> lstAppareilRestitue, SqlCommand cmds)
        {
            foreach (CsAppareilUtiliserFrd st in lstAppareilRestitue)
            {
                cmds.CommandTimeout = 360;
                cmds.CommandType = CommandType.StoredProcedure;
                cmds.CommandText = "SPX_FRD_UPDATE_APPAREILRESTITUE";
                if (cmds.Parameters != null && cmds.Parameters.Count != 0) cmds.Parameters.Clear();
                cmds.Parameters.Add("@RESTITUE", SqlDbType.Int).Value = st.RESTITUE;
                cmds.Parameters.Add("@FK_IDAPPAREIL", SqlDbType.Int).Value = st.FK_IDAPPAREIL;
                cmds.Parameters.Add("@FICHECONTROLE", SqlDbType.VarChar, 20).Value = st.FicheControle;
                DBBase.SetDBNullParametre(cmds.Parameters);

                try
                {
                    if (cmds.Connection.State == ConnectionState.Closed)
                        cmds.Connection.Open();
                    cmds.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(cmds.CommandText + ":" + ex.Message);
                }
            }

        }

        public void InsertDEMANDEFRAUDE(CsFraude DemFraude, SqlCommand cmds)
        {

            cmds.CommandTimeout = 360;
            cmds.CommandType = CommandType.StoredProcedure;
            cmds.CommandText = "SPX_FRD_INSERT_FRAUDE";
            if (cmds.Parameters != null && cmds.Parameters.Count != 0) cmds.Parameters.Clear();
            cmds.Parameters.Add("@IsConvocationRespectee", SqlDbType.Bit).Value = DemFraude.IsConvocationRespectee;
            cmds.Parameters.Add("@IsFraudeConfirmee", SqlDbType.Bit).Value = DemFraude.IsFraudeConfirmee;
            cmds.Parameters.Add("@MontantCaution", SqlDbType.Decimal).Value = DemFraude.MontantCaution;
            cmds.Parameters.Add("@DateReclamation", SqlDbType.DateTime).Value = DemFraude.DateReclamation;
            cmds.Parameters.Add("@MotifReclamation", SqlDbType.VarChar, 27).Value = DemFraude.MotifReclamation;
            cmds.Parameters.Add("@DateCreation", SqlDbType.DateTime).Value = DemFraude.DateCreation;
            cmds.Parameters.Add("@DateEtape", SqlDbType.DateTime).Value = DemFraude.DateEtape;
            cmds.Parameters.Add("@FicheTraitement", SqlDbType.VarChar, 14).Value = DemFraude.FicheTraitement;
            cmds.Parameters.Add("@OrdreTraitement", SqlDbType.Int).Value = DemFraude.OrdreTraitement;
            cmds.Parameters.Add("@BordereauTransmission", SqlDbType.VarChar, 14).Value = DemFraude.BordereauTransmission;
            cmds.Parameters.Add("@FK_IDCLIENTFRAUDE", SqlDbType.Int).Value = DemFraude.FK_IDCLIENTFRAUDE;
            cmds.Parameters.Add("@FK_IDDENONCIATEUR", SqlDbType.Int).Value = DemFraude.FK_IDDENONCIATEUR;
            cmds.Parameters.Add("@FK_IDSOURCECONTROLE", SqlDbType.Int).Value = DemFraude.FK_IDSOURCECONTROLE;
            cmds.Parameters.Add("@FK_IDDECISIONFRAUDE", SqlDbType.Int).Value = DemFraude.FK_IDDECISIONFRAUDE;
            cmds.Parameters.Add("@FK_IDDEMANDE", SqlDbType.Int).Value = DemFraude.FK_IDDEMANDE;
            //cmds.Parameters.Add("@TYPEFACTURATION", SqlDbType.Int).Value = DemFraude.TYPEFACTURATION;

            SqlParameter outResult = new SqlParameter("@PK_ID", SqlDbType.VarChar, int.MaxValue) { Direction = ParameterDirection.Output };
            outResult.Value = DemFraude.PK_ID;
            cmds.Parameters.Add(outResult);
            DBBase.SetDBNullParametre(cmds.Parameters);

            try
            {
                string IdFraude = string.Empty;
                if (cmds.Connection.State == ConnectionState.Closed)
                    cmds.Connection.Open();
                cmds.ExecuteNonQuery();
                IdFraude = outResult.Value != null ? outResult.Value.ToString() : "1";
                DemFraude.PK_ID = int.Parse(IdFraude);
            }
            catch (Exception ex)
            {
                throw new Exception(cmds.CommandText + ":" + ex.Message);
            }
        }

        public void UpdateDEMANDEFRAUDE(CsFraude DemFraude, SqlCommand cmds)
        {

            cmds.CommandTimeout = 360;
            cmds.CommandType = CommandType.StoredProcedure;
            cmds.CommandText = "SPX_FRD_UPDATE_FRAUDE";
            if (cmds.Parameters != null && cmds.Parameters.Count != 0) cmds.Parameters.Clear();
            cmds.Parameters.Add("@IsConvocationRespectee", SqlDbType.Bit).Value = DemFraude.IsConvocationRespectee;
            cmds.Parameters.Add("@IsFraudeConfirmee", SqlDbType.Bit).Value = DemFraude.IsFraudeConfirmee;
            cmds.Parameters.Add("@MontantCaution", SqlDbType.Decimal).Value = DemFraude.MontantCaution;
            cmds.Parameters.Add("@DateReclamation", SqlDbType.DateTime).Value = DemFraude.DateReclamation;
            cmds.Parameters.Add("@MotifReclamation", SqlDbType.VarChar, 27).Value = DemFraude.MotifReclamation;
            cmds.Parameters.Add("@DateCreation", SqlDbType.DateTime).Value = DemFraude.DateCreation;
            cmds.Parameters.Add("@DateEtape", SqlDbType.DateTime).Value = DemFraude.DateEtape;
            cmds.Parameters.Add("@FicheTraitement", SqlDbType.VarChar, 14).Value = DemFraude.FicheTraitement;
            cmds.Parameters.Add("@OrdreTraitement", SqlDbType.Int).Value = DemFraude.OrdreTraitement;
            cmds.Parameters.Add("@BordereauTransmission", SqlDbType.VarChar, 14).Value = DemFraude.BordereauTransmission;
            cmds.Parameters.Add("@FK_IDCLIENTFRAUDE", SqlDbType.Int).Value = DemFraude.FK_IDCLIENTFRAUDE;
            cmds.Parameters.Add("@FK_IDDENONCIATEUR", SqlDbType.Int).Value = DemFraude.FK_IDDENONCIATEUR;
            cmds.Parameters.Add("@FK_IDSOURCECONTROLE", SqlDbType.Int).Value = DemFraude.FK_IDSOURCECONTROLE;
            cmds.Parameters.Add("@FK_IDDECISIONFRAUDE", SqlDbType.Int).Value = DemFraude.FK_IDDECISIONFRAUDE;
            cmds.Parameters.Add("@FK_IDDEMANDE", SqlDbType.Int).Value = DemFraude.FK_IDDEMANDE;
            cmds.Parameters.Add("@PK_ID", SqlDbType.Int).Value = DemFraude.PK_ID;

            DBBase.SetDBNullParametre(cmds.Parameters);

            try
            {
                if (cmds.Connection.State == ConnectionState.Closed)
                    cmds.Connection.Open();
                cmds.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(cmds.CommandText + ":" + ex.Message);
            }
        }



        public void InsertorUpdateAUDITIONFRAUDE(CsAuditionFraude  AuditionFraude, SqlCommand cmds)
        {

            cmds.CommandTimeout = 360;
            cmds.CommandType = CommandType.StoredProcedure;
            cmds.CommandText = "SPX_FRD_INSERTorUPDATE_AUDITION";
            if (cmds.Parameters != null && cmds.Parameters.Count != 0) cmds.Parameters.Clear();
            cmds.Parameters.Add("@DateRendezVous", SqlDbType.DateTime).Value = AuditionFraude.DateRendezVous;
            cmds.Parameters.Add("@DateAudition", SqlDbType.DateTime ).Value = AuditionFraude.DateAudition;
            cmds.Parameters.Add("@NomRepondant", SqlDbType.VarChar,63).Value = AuditionFraude.NomRepondant;
            cmds.Parameters.Add("@QualiteRepondant", SqlDbType.VarChar ,63).Value = AuditionFraude.QualiteRepondant;
            cmds.Parameters.Add("@IsProprietaire", SqlDbType.Bit).Value = AuditionFraude.IsProprietaire;
            cmds.Parameters.Add("@IsMaisonHabitee", SqlDbType.Bit ).Value = AuditionFraude.IsMaisonHabitee;
            cmds.Parameters.Add("@NombreHabitant", SqlDbType.Int ).Value = AuditionFraude.NombreHabitant;
            cmds.Parameters.Add("@IsDejaDepanne", SqlDbType.Bit ).Value = AuditionFraude.IsDejaDepanne;
            cmds.Parameters.Add("@MotifDepannage", SqlDbType.VarChar ,255).Value = AuditionFraude.MotifDepannage;
            cmds.Parameters.Add("@IsDejaPenaliseSurCompteur", SqlDbType.Bit).Value = AuditionFraude.IsDejaPenaliseSurCompteur;
            cmds.Parameters.Add("@IsFacturePenaliteDejaRecue", SqlDbType.Bit).Value = AuditionFraude.IsFacturePenaliteDejaRecue;
            cmds.Parameters.Add("@IsDemandeVerificationDejaEmise", SqlDbType.Bit ).Value = AuditionFraude.IsDemandeVerificationDejaEmise;
            cmds.Parameters.Add("@IsAccuseReceptionDemande", SqlDbType.Bit).Value = AuditionFraude.IsAccuseReceptionDemande;
            cmds.Parameters.Add("@IsCertificatPlombageRecu", SqlDbType.Bit ).Value = AuditionFraude.IsCertificatPlombageRecu;
            cmds.Parameters.Add("@IsNewAppareilAcquis", SqlDbType.Bit).Value = AuditionFraude.IsNewAppareilAcquis;
            cmds.Parameters.Add("@FK_IDPROCESVERBALSCANNE", SqlDbType.UniqueIdentifier).Value = AuditionFraude.FK_IDPROCESVERBALSCANNE;
            cmds.Parameters.Add("@FK_IDFRAUDE", SqlDbType.Int ).Value = AuditionFraude.FK_IDFRAUDE;
            DBBase.SetDBNullParametre(cmds.Parameters);

            try
            {
                if (cmds.Connection.State == ConnectionState.Closed)
                    cmds.Connection.Open();
                cmds.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(cmds.CommandText + ":" + ex.Message);
            }
        }

        public void InsertorUpdateCONSOMMAION(CsConsommationFrd  ConsommationFraude, SqlCommand cmds)
        {

            cmds.CommandTimeout = 360;
            cmds.CommandType = CommandType.StoredProcedure;
            cmds.CommandText = "SPX_FRD_INSERTorUPDATE_CONSOMMATION";
            if (cmds.Parameters != null && cmds.Parameters.Count != 0) cmds.Parameters.Clear();
            cmds.Parameters.Add("@ConsommationEstimee", SqlDbType.Int).Value = ConsommationFraude.ConsommationEstimee;
            cmds.Parameters.Add("@ConsommationAFacturer", SqlDbType.Int ).Value = ConsommationFraude.ConsommationAFacturer;
            cmds.Parameters.Add("@ConsommationDejaFacturee", SqlDbType.Int).Value = ConsommationFraude.ConsommationDejaFacturee;
            cmds.Parameters.Add("@periodeDebut", SqlDbType.VarChar ,10).Value = ConsommationFraude.PERIODEDEBUT ;
            cmds.Parameters.Add("@periodeFin", SqlDbType.VarChar ,10).Value = ConsommationFraude.PERIODEFIN ;
            cmds.Parameters.Add("@FK_IDFRAUDE", SqlDbType.Int ).Value = ConsommationFraude.FK_IDFRAUDE;
            cmds.Parameters.Add("@FK_IDPRODUIT", SqlDbType.Int).Value = ConsommationFraude.FK_IDPRODUIT;
            cmds.Parameters.Add("@USERCREATION", SqlDbType.VarChar, 6).Value = ConsommationFraude.USERCREATION;
            cmds.Parameters.Add("@TYPEFACTURATION", SqlDbType.Int).Value = ConsommationFraude.TYPEFACTURATION;
            DBBase.SetDBNullParametre(cmds.Parameters);

            try
            {
                if (cmds.Connection.State == ConnectionState.Closed)
                    cmds.Connection.Open();
                cmds.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(cmds.CommandText + ":" + ex.Message);
            }
        }
        
        public void ValiderFactureFraude(string lot, string numdem,string Matricule, SqlCommand cmds)
        {
            cmds.CommandTimeout = 360;
            cmds.CommandType = CommandType.StoredProcedure;
            //cmds.CommandText = "SPX_FRD_VALIDER_FACTURE";
            cmds.CommandText = "SPX_FAC_MISE_A_JOUR_FACTURE_FRD";
            if (cmds.Parameters != null && cmds.Parameters.Count != 0) cmds.Parameters.Clear();
            cmds.Parameters.Add("@lotri", SqlDbType.VarChar, 8).Value = lot;
            cmds.Parameters.Add("@numdem", SqlDbType.VarChar, 20).Value = numdem;
            cmds.Parameters.Add("@matricule", SqlDbType.VarChar, 5).Value = Matricule;
            DBBase.SetDBNullParametre(cmds.Parameters);

            try
            {
                string IdClientF = string.Empty;
                if (cmds.Connection.State == ConnectionState.Closed)
                    cmds.Connection.Open();
                cmds.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(cmds.CommandText + ":" + ex.Message);
            }
        }




        public void SupprimerDetail(int idFraude, SqlCommand cmds)
        {
            cmds.CommandTimeout = 360;
            cmds.CommandType = CommandType.StoredProcedure;
            cmds.CommandText = "SPX_FRD_DELETE_DETAIL";
            if (cmds.Parameters != null && cmds.Parameters.Count != 0) cmds.Parameters.Clear();
            cmds.Parameters.Add("@idFraude", SqlDbType.Int).Value = idFraude;
            DBBase.SetDBNullParametre(cmds.Parameters);

            try
            {
                if (cmds.Connection.State == ConnectionState.Closed)
                    cmds.Connection.Open();
                cmds.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(cmds.CommandText + ":" + ex.Message);
            }
        }

        public void ValiderCalcul(string numdem, SqlCommand cmds)
        {
            cmds.CommandTimeout = 360;
            cmds.CommandType = CommandType.StoredProcedure;
            cmds.CommandText = "SPX_FRD_VALIDER_CALCUL";
            if (cmds.Parameters != null && cmds.Parameters.Count != 0) cmds.Parameters.Clear();
            cmds.Parameters.Add("@numdem", SqlDbType.VarChar, 20).Value = numdem;
            DBBase.SetDBNullParametre(cmds.Parameters);

            try
            {
                if (cmds.Connection.State == ConnectionState.Closed)
                    cmds.Connection.Open();
                cmds.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(cmds.CommandText + ":" + ex.Message);
            }
        }

        public void InsertorUpdateDetailTranche(List<CsDETAILparTRANCHE> leDetailTranche, SqlCommand cmds)
        {
            Galatee.Tools.Utility.InsertionEnBloc<CsDETAILparTRANCHE>(leDetailTranche, "frd.DETAILparTRANCHE", cmds);
        }
        public void InsertorUpdateDetailPrestation(List<CsDetailParPresentationEdm > leDetailPrestationEdm, SqlCommand cmds)
        {
            Galatee.Tools.Utility.InsertionEnBloc<CsDetailParPresentationEdm>(leDetailPrestationEdm, "frd.DETAILparPRESTATIONEDM", cmds);
        }
        public void InsertorUpdateDetailPrestationRemboursable(List<CsDETAILparPRESTATIONREMBOURSABLE > leDetailPrestationRemb, SqlCommand cmds)
        {
            Galatee.Tools.Utility.InsertionEnBloc<CsDETAILparPRESTATIONREMBOURSABLE>(leDetailPrestationRemb, "frd.DETAILparPRESTATIONREMBOURSABLE", cmds);
        }
        public void InsertorUpdateDetailRegarisation(List<CsDETAILparREGULARISATION > leDetailRegarisation, SqlCommand cmds)
        {
            Galatee.Tools.Utility.InsertionEnBloc<CsDETAILparREGULARISATION>(leDetailRegarisation, "frd.DETAILparREGULARISATION", cmds);
        }
        #endregion
        public string FormatPeriodeMMAAAA(string periode)
        {
            if (periode.Length == 6)
                return periode.Substring(4, 2).PadLeft(2, '0') + "/" + periode.Substring(0, 4);
            else return string.Empty;
        }

        public int SelectNombreDemandeFraude(string centre)
        {

            cn = new SqlConnection(ConnectString);

            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandTimeout = 180;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SPX_FRD_SELECTNOMBREDEMANDEFRAUDE";
            cmd.Parameters.Add("@CENTRE", SqlDbType.VarChar,Enumere.TailleCentre ).Value = centre;
            DBBase.SetDBNullParametre(cmd.Parameters);
            try
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                int NombreDemande = 0;

                if (reader.Read())
                    NombreDemande = (Convert.IsDBNull(reader["NOMBREEDEMANDE"])) ? 0 : (int)reader["NOMBREEDEMANDE"];
                return NombreDemande;
            }
            catch (Exception ex)
            {
                throw new Exception(cmd.CommandText + ":" + ex.Message);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close(); // Fermeture de la connection 
                cmd.Dispose();
            }
        }

        public DataTable CalculeDuLotSpx(string Lotri, string periode, int? exig, bool IsSimulation, string matricule, bool IsMt, bool IsIsole, string NumDemande)
        {
            cn = new SqlConnection(ConnectionString);

            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandTimeout = 720;
            cmd.CommandType = CommandType.StoredProcedure;
            if (!IsMt)
                cmd.CommandText = "SPX_FAC_CALCUL_FACTURATION_BT_FRAUDE";
            else
                cmd.CommandText = "SPX_FAC_CALCUL_FACTURATION_MT";

            cmd.Parameters.Add("@Lotri", SqlDbType.VarChar, 8).Value = Lotri;
            cmd.Parameters.Add("@Periode", SqlDbType.VarChar, 6).Value = periode;
            cmd.Parameters.Add("@Exig", SqlDbType.Int).Value = exig;
            cmd.Parameters.Add("@Simulation", SqlDbType.Bit).Value = IsSimulation;
            cmd.Parameters.Add("@Matricule", SqlDbType.VarChar, 5).Value = matricule;
            cmd.Parameters.Add("@Isole", SqlDbType.Bit).Value = IsIsole;
            cmd.Parameters.Add("@NumDemande", SqlDbType.VarChar ,20).Value = NumDemande;

            DBBase.SetDBNullParametre(cmd.Parameters);
            try
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                //if (reader.Read())
                dt.Load(reader);

                return dt;

            }
            catch (Exception ex)
            {
                throw new Exception(cmd.CommandText + ":" + ex.Message);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close(); // Fermeture de la connection 
                cmd.Dispose();
            }
        }


    }
}
