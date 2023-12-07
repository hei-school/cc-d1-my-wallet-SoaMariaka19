class Wallet {
    constructor() {
        this.solde = 0.0;
        this.history = [];
    }

    addMoney(amount) {
        this.solde += amount;
        this.saveTransaction(`Ajout d'argent : +${amount} Ar`);
        console.log(`Argent ajouté au portefeuille. Solde actuel : ${this.solde} Ar`);
    }

    withdrawMoney(amount) {
        if (amount <= this.solde) {
            this.solde -= amount;
            this.saveTransaction(`Retrait d'argent : -${amount} Ar`);
            console.log(`Argent retiré du portefeuille. Solde actuel : ${this.solde} Ar`);
        } else {
            console.log("Solde insuffisant.");
        }
    }

    showBalance() {
        console.log(`Solde actuel du portefeuille : ${this.solde} Ar`);
    }

    calculateInterest(rateInterest) {
        const interest = this.solde * (rateInterest / 100);
        this.solde += interest;
        this.saveTransaction(`Calcul des intérêts : +${interest} Ar`);
        console.log(`Intérêts calculés. Nouveau solde : ${this.solde} Ar`);
    }

    showHistory() {
        console.log("\nHistorique des transactions : ");
        this.history.forEach(transaction => console.log(transaction));
    }

    saveTransaction(transaction) {
        this.history.push(transaction);
    }
}

const wallet = new Wallet();
const readlineSync = require('readline-sync');

console.log("Bienvenue dans votre portefeuille !");

let choice;

do {
    console.log("\n1. Ajouter de l'argent");
    console.log("2. Retirer de l'argent");
    console.log("3. Afficher le solde");
    console.log("4. Calculer des intérêts");
    console.log("5. Afficher l'historique des transactions");
    console.log("6. Quitter");
    choice = parseInt(readlineSync.question('Choix : '));

    switch (choice) {
        case 1:
            const amountAdd = parseFloat(readlineSync.question('Montant à ajouter : '));
            wallet.addMoney(amountAdd);
            break;
        case 2:
            const amountWithdrawal = parseFloat(readlineSync.question('Montant à retirer : '));
            wallet.withdrawMoney(amountWithdrawal);
            break;
        case 3:
            wallet.showBalance();
            break;
        case 4:
            const rateInterest = parseFloat(readlineSync.question('Taux d\'intérêt (%) : '));
            wallet.calculateInterest(rateInterest);
            break;
        case 5:
            wallet.showHistory();
            break;
        case 6:
            console.log("Au revoir ! Merci d'avoir utilisé votre portefeuille.");
            break;
        default:
            console.log("Choix non valide.");
    }
} while (choice !== 6);
