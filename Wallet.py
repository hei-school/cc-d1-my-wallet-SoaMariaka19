class Wallet:
    def __init__(self):
        self.solde = 0.0
        self.history = []

    def add_money(self, amount):
        self.solde += amount
        self.save_transaction(f"Ajout d'argent : +{amount} Ar")
        print(f"Argent ajouté au portefeuille. Solde actuel : {self.solde} Ar")

    def withdraw_money(self, amount):
        if amount <= self.solde:
            self.solde -= amount
            self.save_transaction(f"Retrait d'argent : -{amount} Ar")
            print(f"Argent retiré du portefeuille. Solde actuel : {self.solde} Ar")
        else:
            print("Solde insuffisant.")

    def show_balance(self):
        print(f"Solde actuel du portefeuille : {self.solde} Ar")

    def calculate_interest(self, rate_interest):
        interest = self.solde * (rate_interest / 100)
        self.solde += interest
        self.save_transaction(f"Calcul des intérêts : +{interest} Ar")
        print(f"Intérêts calculés. Nouveau solde : {self.solde} Ar")

    def show_history(self):
        print("\nHistorique des transactions : ")
        for transaction in self.history:
            print(transaction)

    def save_transaction(self, transaction):
        self.history.append(transaction)

wallet = Wallet()
print("Bienvenue dans votre portefeuille !")

while True:
    print("\n1. Ajouter de l'argent")
    print("2. Retirer de l'argent")
    print("3. Afficher le solde")
    print("4. Calculer des intérêts")
    print("5. Afficher l'historique des transactions")
    print("6. Quitter")
    choice = int(input("Choix : "))

    if choice == 1:
        amount_add = float(input("Montant à ajouter : "))
        wallet.add_money(amount_add)
    elif choice == 2:
        amount_withdrawal = float(input("Montant à retirer : "))
        wallet.withdraw_money(amount_withdrawal)
    elif choice == 3:
        wallet.show_balance()
    elif choice == 4:
        rate_interest = float(input("Taux d'intérêt (%) : "))
        wallet.calculate_interest(rate_interest)
    elif choice == 5:
        wallet.show_history()
    elif choice == 6:
        print("Au revoir ! Merci d'avoir utilisé votre portefeuille.")
        break
    else:
        print("Choix non valide.")
