using GestionStock.Data;
using GestionStock.UserInterface;
// using GestionStock.UserInterface;


namespace GestionStock
{
    static class Program
    {
        // Cr�er une instance statique unique du DataManager
        public static DataManager dataManager;

        /// <summary>
        /// Point d'entr�e principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Initialiser le DataManager (ce qui chargera les donn�es)
            // G�rer les exceptions potentielles lors du chargement initial ici si n�cessaire
            try
            {
                dataManager = new DataManager();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur critique lors du chargement des donn�es initiales : {ex.Message}\nL'application va se fermer.", "Erreur de D�marrage", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Emp�che l'application de d�marrer si les donn�es ne peuvent pas �tre charg�es
            }


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Lancer MainForm au lieu de Form1
            Application.Run(new MainForm());
        }
    }
}