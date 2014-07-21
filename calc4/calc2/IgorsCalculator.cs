using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calc2 {
	// знак дії 
	public enum znaky { 
		pusto, 
		plus, 
		minus, 
		mnozh, 
		dilen
	};

	public class IgorsCalculator {
		
		// Після виконання операції результат повинен зписуватись в цю змінну. Вона може приймати значення null
		private double? latestResult;

		// Остання операція
		private znaky latestOperation;

		// Останній операнд
		private double? latestOperand;

		// Kонструктор. Tут, думаю, нічого не треба міняти
		public IgorsCalculator() {
			latestResult = null;
			latestOperand = null;
			latestOperation = znaky.pusto;
		}

		// обнулити дані "С".
		public void resetData() {
			latestResult = null;
			latestOperand = null;
			latestOperation = znaky.pusto;
		}

		// +
		public double add(double a, double? b) {
			// якщо b.HasValue, то повернути суму а + b і в latestOperand записати b
			// інакше до повернути суму останнього результату і числа а. В latestOperand записати b
			return 0;
		}

		// -
		public double sub(double a, double? b) {
			// аналогічно до суми
			return 0;
		}

		// *
		public double mul(double a, double? b) {
			// аналогічно до суми
			return 0;
		}

		// /
		public double div(double a, double? b) {
			// аналогічно до суми 

			// і в місці, де викликається цей метод, потрібно додати блок try { } catch(Exception e) { }, якщо щось не вийде, то напишеш. 
			// Бо тут може бути ділення на нуль. 
			// Наступний код нормальний, але не зручний. Коли таких перевірок стає дуже багато, з ними важко працювати. 
			// Просто робиш Exception, і в коді перевіряєш чи не виникла помилка, на екран виводиш одне якесь стандартне повідомлення.
			// if (Convert.ToDouble(textBox1.Text) == 0)
			// {
			//      textBox1.Text = "На ноль нельзя!";
			//  	znak = znaky.pusto;
			//  	dilenzero = true;
			//  	flag = false;
			// }
			return 0;
		}
		
		// змінити знак
		public double reverse(double? b) {
			// якщо b.HasValue, то повернути обернене значення
			// інакше повернути обернене значення до останнього результату. 
			return 0;
		}

		// корінь
		public double sqrt(double? b) {
			// якщо b.HasValue, то повернути обернене значення
			// інакше повернути обернене значення до останнього результату. 

			// і в місці, де викликається цей метод, потрібно додати блок try { } catch(Exception e) { }, якщо щось не вийде, то напишеш. 
			// Бо тут може бути ділення на нуль. 
			// Наступний код нормальний, але не зручний. Коли таких перевірок стає дуже багато, з ними важко працювати. 
			// Просто робиш Exception, і в коді перевіряєш чи не виникла помилка, на екран виводиш одне якесь стандартне повідомлення.
			// if (Convert.ToDouble(textBox1.Text) == 0)
			// {
			//      textBox1.Text = "На ноль нельзя!";
			//  	znak = znaky.pusto;
			//  	dilenzero = true;
			//  	flag = false;
			// }
			return 0;
		}

		// 1/x
		public double x1(double? b) {
			// аналогічно до кореня
			return 0;
		}
		
		// повторити останню операцію
		public double repeat() {
			// якщо жодної операції ще не було, то throw new Exception("Eroor");
			return 0;		
		}
	}
}
