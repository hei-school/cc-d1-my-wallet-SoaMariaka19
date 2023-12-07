using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Bienvenue dans votre portefeuille !");
        Wallet wallet = new Wallet();
        int choice;

        do
        {
            Console.WriteLine("\n1. Ajouter de l'argent");
            Console.WriteLine("2. Retirer de l'argent");
            Console.WriteLine("3. Afficher le solde");
            Console.WriteLine("4. Calculer des intérêts");
            Console.WriteLine("5. Afficher l'historique des transactions");
            Console.WriteLine("6. Quitter");
            Console.Write("Choix : ");

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("Montant à ajouter : ");
                        if (double.TryParse(Console.ReadLine(), out double amountToAdd))
                        {
                            wallet.AddMoney(amountToAdd);
                        }
                        else
                        {
                            Console.WriteLine("Saisie non valide. Veuillez entrer un nombre.");
                        }
                        break;

                    case 2:
                        Console.Write("Montant à retirer : ");
                        if (double.TryParse(Console.ReadLine(), out double amountToWithdraw))
                        {
                            wallet.WithdrawMoney(amountToWithdraw);
                        }
                        else
                        {
                            Console.WriteLine("Saisie non valide. Veuillez entrer un nombre.");
                        }
                        break;

                    case 3:
                        wallet.ShowBalance();
                        break;

                    case 4:
                        Console.Write("Taux d'intérêt (%) : ");
                        if (double.TryParse(Console.ReadLine(), out double rateInterest))
                        {
                            wallet.CalculateInterest(rateInterest);
                        }
                        else
                        {
                            Console.WriteLine("Saisie non valide. Veuillez entrer un nombre.");
                        }
                        break;

                    case 5:
                        wallet.ShowHistory();
                        break;

                    case 6:
                        Console.WriteLine("Au revoir ! Merci d'avoir utilisé votre portefeuille.");
                        break;

                    default:
                        Console.WriteLine("Choix non valide.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Saisie non valide. Veuillez entrer un nombre entier.");
            }
        } while (choice != 6);
    }
}

public class Wallet
{
    private double solde;
    private List<string> history = new List<string>();

    public Wallet()
    {
        this.solde = 0.0;
    }

    public void AddMoney(double amount)
    {
        this.solde += amount;
        SaveTransaction($"Ajout d'argent : +{amount} Ar");
        Console.WriteLine($"Argent ajouté au portefeuille. Solde actuel : {this.solde} Ar");
    }

    public void WithdrawMoney(double amount)
    {
        if (amount <= this.solde)
        {
            this.solde -= amount;
            SaveTransaction($"Retrait d'argent : -{amount} Ar");
            Console.WriteLine($"Argent retiré du portefeuille. Solde actuel : {this.solde} Ar");
        }
        else
        {
            Console.WriteLine("Solde insuffisant.");
        }
    }

    public void ShowBalance()
    {
        Console.WriteLine($"Solde actuel du portefeuille : {this.solde} Ar");
    }

    public void CalculateInterest(double rateInterest)
    {
        double interest = this.solde * (rateInterest / 100);
        this.solde += interest;
        SaveTransaction($"Calcul des intérêts : +{interest} Ar");
        Console.WriteLine($"Intérêts calculés. Nouveau solde : {this.solde} Ar");
    }

    public void ShowHistory()
    {
        Console.WriteLine("\nHistorique des transactions : ");
        foreach (string transaction in this.history)
        {
            Console.WriteLine(transaction);
        }
    }

    private void SaveTransaction(string transaction)
    {
        this.history.Add(transaction);
    }
}
