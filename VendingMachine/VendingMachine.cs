using System;
namespace VendingMachine
{
    public class VendingMachine
    {
        private int yen500 = 0;
        private int yen100 = 0;
        private int yen50 = 0;
        private int yen10 = 0;

        private int entryPrice = 0; // 投入金額
        private int change = 0; // お釣り

        public VendingMachine()
        {
        }

        public void AddAmount(int yen500, int yen100, int yen50, int yen10)
        {
            this.yen500 += yen500;
            this.yen100 += yen100;
            this.yen50 += yen50;
            this.yen10 += yen10;
        }

        public void PutMoney(int price)
        {
            this.entryPrice = price;
            this.change = price;
        }

        public void Purchase(int price)
        {
            this.change -= price; //お釣り
        }

        public string GetChange()
        {
            int requiredNumber;
            int yen500Number = 0;
            int yen100Number = 0;
            int yen50Number = 0;
            int yen10Number = 0;
            string ret = string.Empty;

            // お釣り枚数計算
            requiredNumber = this.CalcChange(500); yen500Number = requiredNumber;
            ret += " " + requiredNumber;

            requiredNumber = this.CalcChange(100); yen100Number = requiredNumber;
            ret += " " + requiredNumber;

            requiredNumber = this.CalcChange(50); yen50Number = requiredNumber;
            ret += " " + requiredNumber;

            requiredNumber = this.CalcChange(10); yen10Number = requiredNumber;
            ret += " " + requiredNumber;

            if (this.change > 0)
            {
                this.Modoshi(yen500Number, yen100Number, yen50Number, yen10Number);
                return "impossible";
            }
            if (yen50Number * 50 + yen10Number * 10 >= 100)
            {
                this.Modoshi(yen500Number, yen100Number, yen50Number, yen10Number);
                return "impossible";
            }

            return ret.Substring(1);
        }

        private void Modoshi(int yen500, int yen100, int yen50, int yen10)
        {
            this.yen500 -= yen500;
            this.yen100 -= yen100;
            this.yen50 -= yen50;
            this.yen10 -= yen100;

        }

        private int CalcChange(int moneyUnit)
        {
            int requiredNumber;
            requiredNumber = this.CalcChange(this.change, moneyUnit);
            if (requiredNumber == 0) return 0;

            switch (moneyUnit)
            {
                case 500:
                    if (this.yen500 < requiredNumber) return 0;
                    this.yen500 -= requiredNumber;
                    break;
                case 100:
                    if (this.yen100 < requiredNumber) return 0;
                    this.yen100 -= requiredNumber;
                    break;
                case 50:
                    if (this.yen50 < requiredNumber) return 0;
                    this.yen50 -= requiredNumber;
                    break;
                case 10:
                    if (this.yen10 < requiredNumber) return 0;
                    this.yen10 -= requiredNumber;
                    break;
            }

            DecrementChange(requiredNumber, moneyUnit);
            return requiredNumber;
        }

        private int CalcChange(int changeRemaining, int moneyUnit)
        {
            return changeRemaining / moneyUnit;
        }

        private void DecrementChange(int requiredNumber, int moneyUnit)
        {
            this.change -= requiredNumber * moneyUnit;
        }
    }
}
