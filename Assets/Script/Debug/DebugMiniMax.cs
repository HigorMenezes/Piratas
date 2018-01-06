using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMiniMax : MonoBehaviour {

	void Start () {

		Nodo nodo1 = new Nodo ();
		nodo1.MaxMin = Nodo.MaxOrMin.Max;
		nodo1.Name = "nodo1";

		Nodo nodo2 = new Nodo ();
		nodo2.MaxMin = Nodo.MaxOrMin.Min;
		nodo2.Name = "nodo2";
		Nodo nodo3 = new Nodo ();
		nodo3.MaxMin = Nodo.MaxOrMin.Min;
		nodo3.Name = "nodo3";

		Nodo nodo4 = new Nodo ();
		nodo4.MaxMin = Nodo.MaxOrMin.Max;
		nodo4.Name = "nodo4";
		Nodo nodo5 = new Nodo ();
		nodo5.MaxMin = Nodo.MaxOrMin.Max;
		nodo5.Name = "nodo5";
		Nodo nodo6 = new Nodo ();
		nodo6.MaxMin = Nodo.MaxOrMin.Max;
		nodo6.Name = "nodo6";
		Nodo nodo7 = new Nodo ();
		nodo7.MaxMin = Nodo.MaxOrMin.Max;
		nodo7.Name = "nodo7";

		Nodo nodo8 = new Nodo ();
		nodo8.MaxMin = Nodo.MaxOrMin.Min;
		nodo8.Name = "nodo8";
		Nodo nodo9 = new Nodo ();
		nodo9.MaxMin = Nodo.MaxOrMin.Min;
		nodo9.Name = "nodo9";
		Nodo nodo10 = new Nodo ();
		nodo10.MaxMin = Nodo.MaxOrMin.Min;
		nodo10.Name = "nodo10";
		Nodo nodo11 = new Nodo ();
		nodo11.MaxMin = Nodo.MaxOrMin.Min;
		nodo11.Name = "nodo11";
		Nodo nodo12 = new Nodo ();
		nodo12.MaxMin = Nodo.MaxOrMin.Min;
		nodo12.Name = "nodo12";
		Nodo nodo13 = new Nodo ();
		nodo13.MaxMin = Nodo.MaxOrMin.Min;
		nodo13.Name = "nodo13";
		Nodo nodo14 = new Nodo ();
		nodo14.MaxMin = Nodo.MaxOrMin.Min;
		nodo14.Name = "nodo14";
		Nodo nodo15 = new Nodo ();
		nodo15.MaxMin = Nodo.MaxOrMin.Min;
		nodo15.Name = "nodo15";

		Nodo nodo16 = new Nodo ();
		nodo16.FUtility = 8f;
		nodo16.MaxMin = Nodo.MaxOrMin.Max;
		nodo16.Name = "nodo16";
		Nodo nodo17 = new Nodo ();
		nodo17.FUtility = 23f;
		nodo17.MaxMin = Nodo.MaxOrMin.Max;
		nodo17.Name = "nodo17";
		Nodo nodo18 = new Nodo ();
		nodo18.FUtility = -47f;
		nodo18.MaxMin = Nodo.MaxOrMin.Max;
		nodo18.Name = "nodo18";
		Nodo nodo19 = new Nodo ();
		nodo19.FUtility = 28f;
		nodo19.MaxMin = Nodo.MaxOrMin.Max;
		nodo19.Name = "nodo19";
		Nodo nodo20 = new Nodo ();
		nodo20.FUtility = -30f;
		nodo20.MaxMin = Nodo.MaxOrMin.Max;
		nodo20.Name = "nodo20";
		Nodo nodo21 = new Nodo ();
		nodo21.FUtility = -37f;
		nodo21.MaxMin = Nodo.MaxOrMin.Max;
		nodo21.Name = "nodo21";
		Nodo nodo22 = new Nodo ();
		nodo22.FUtility = 3f;
		nodo22.MaxMin = Nodo.MaxOrMin.Max;
		nodo22.Name = "nodo22";
		Nodo nodo23 = new Nodo ();
		nodo23.FUtility = -41f;
		nodo23.MaxMin = Nodo.MaxOrMin.Max;
		nodo23.Name = "nodo23";
		Nodo nodo24 = new Nodo ();
		nodo24.FUtility = -19f;
		nodo24.MaxMin = Nodo.MaxOrMin.Max;
		nodo24.Name = "nodo24";
		Nodo nodo25 = new Nodo ();
		nodo25.FUtility = 4f;
		nodo25.MaxMin = Nodo.MaxOrMin.Max;
		nodo25.Name = "nodo25";
		Nodo nodo26 = new Nodo ();
		nodo26.FUtility = -49f;
		nodo26.MaxMin = Nodo.MaxOrMin.Max;
		nodo26.Name = "nodo26";
		Nodo nodo27 = new Nodo ();
		nodo27.FUtility = 4f;
		nodo27.MaxMin = Nodo.MaxOrMin.Max;
		nodo27.Name = "nodo27";
		Nodo nodo28 = new Nodo ();
		nodo28.FUtility = 43f;
		nodo28.MaxMin = Nodo.MaxOrMin.Max;
		nodo28.Name = "nodo28";
		Nodo nodo29 = new Nodo ();
		nodo29.FUtility = 45f;
		nodo29.MaxMin = Nodo.MaxOrMin.Max;
		nodo29.Name = "nodo29";
		Nodo nodo30 = new Nodo ();
		nodo30.FUtility = -26f;
		nodo30.MaxMin = Nodo.MaxOrMin.Max;
		nodo30.Name = "nodo30";
		Nodo nodo31 = new Nodo ();
		nodo31.FUtility = -14f;
		nodo31.MaxMin = Nodo.MaxOrMin.Max;
		nodo31.Name = "nodo31";

		nodo1.addChildren (nodo3);
		nodo1.addChildren (nodo2);

		nodo2.addChildren (nodo5);
		nodo2.addChildren (nodo4);

		nodo3.addChildren (nodo7);
		nodo3.addChildren (nodo6);

		nodo4.addChildren (nodo9);
		nodo4.addChildren (nodo8);

		nodo5.addChildren (nodo11);
		nodo5.addChildren (nodo10);

		nodo6.addChildren (nodo13);
		nodo6.addChildren (nodo12);

		nodo7.addChildren (nodo15);
		nodo7.addChildren (nodo14);

		nodo8.addChildren (nodo17);
		nodo8.addChildren (nodo16);

		nodo9.addChildren (nodo19);
		nodo9.addChildren (nodo18);

		nodo10.addChildren (nodo21);
		nodo10.addChildren (nodo20);

		nodo11.addChildren (nodo23);
		nodo11.addChildren (nodo22);

		nodo12.addChildren (nodo25);
		nodo12.addChildren (nodo24);

		nodo13.addChildren (nodo27);
		nodo13.addChildren (nodo26);

		nodo14.addChildren (nodo29);
		nodo14.addChildren (nodo28);

		nodo15.addChildren (nodo31);
		nodo15.addChildren (nodo30);



		/*float f = MiniMax.seach (nodo1);
		Debug.Log (f);*/

		DebugTree.imprime (nodo1);

	}
}
