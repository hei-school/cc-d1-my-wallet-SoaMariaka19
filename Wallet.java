import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Wallet {
    private double solde;
    private List<String> history = new ArrayList<>();

    public Wallet() {
        this.solde = 0.0;
    }

    public void addMoney(double amount) {
        this.solde += amount;
        saveTransaction("Ajout d'argent : +" + amount + " Ar");
        System.out.println("Argent ajouté au portefeuille. Solde actuel : " + this.solde + " Ar");
    }

    public void withdrawMoney(double amount) {
        if (amount <= this.solde) {
            this.solde -= amount;
            saveTransaction("Retrait d'argent : -" + amount + " Ar");
            System.out.println("Argent retiré du portefeuille. Solde actuel : " + this.solde + " Ar");
        } else {
            System.out.println("Solde insuffisant.");
        }
    }

    public void showBalance() {
        System.out.println("Solde actuel du portefeuille : " + this.solde + " Ar");
    }

    public void calculateInterest(double rateInterest) {
        double interest = this.solde * (rateInterest / 100);
        this.solde += interest;
        saveTransaction("Calcul des intérêts : +" + interest + " Ar");
        System.out.println("Intérêts calculés. Nouveau solde : " + this.solde + " Ar");
    }

    public void showHistory() {
        System.out.println("\nHistorique des transactions : ");
        for (String transaction : this.history) {
            System.out.println(transaction);
        }
    }

    private void saveTransaction(String transaction) {
        this.history.add(transaction);
    }

    public static void main(String[] args) {
        Wallet wallet = new Wallet();
        Scanner scanner = new Scanner(System.in);
        int choice;

        System.out.println("Bienvenue dans votre portefeuille !");

        do {
            System.out.println("\n1. Ajouter de l'argent");
            System.out.println("2. Retirer de l'argent");
            System.out.println("3. Afficher le solde");
            System.out.println("4. Calculer des intérêts");
            System.out.println("5. Afficher l'historique des transactions");
            System.out.println("6. Quitter");
            System.out.print("Choix : ");
            choice = scanner.nextInt();

            switch (choice) {
                case 1:
                    System.out.print("Montant à ajouter : ");
                    wallet.addMoney(scanner.nextDouble());
                    break;
                case 2:
                    System.out.print("Montant à retirer : ");
                    wallet.withdrawMoney(scanner.nextDouble());
                    break;
                case 3:
                    wallet.showBalance();
                    break;
                case 4:
                    System.out.print("Taux d'intérêt (%) : ");
                    double rateInterest = scanner.nextDouble();
                    wallet.calculateInterest(rateInterest);
                    break;
                case 5:
                    wallet.showHistory();
                    break;
                case 6:
                    System.out.println("Au revoir ! Merci d'avoir utilisé votre portefeuille.");
                    break;
                default:
                    System.out.println("Choix non valide.");
            }
        } while (choice != 6);
    }
}
