using GestionStock.Data;
using GestionStock.UserInterface;
// using GestionStock.UserInterface;


namespace GestionStock
{
    static class Program
    {
        // Créer une instance statique unique du DataManager
        public static DataManager dataManager;

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Initialiser le DataManager (ce qui chargera les données)
            // Gérer les exceptions potentielles lors du chargement initial ici si nécessaire
            try
            {
                dataManager = new DataManager();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur critique lors du chargement des données initiales : {ex.Message}\nL'application va se fermer.", "Erreur de Démarrage", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Empêche l'application de démarrer si les données ne peuvent pas être chargées
            }


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Lancer MainForm au lieu de Form1
            Application.Run(new MainForm());
        }
    }
}