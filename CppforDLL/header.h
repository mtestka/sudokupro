#pragma once

#include <iostream>
#include <ctime>
#include <string>
#include <cstdlib>
#include <fstream>
#include <cmath>

using namespace std;

class myClass{
	public:
		myClass();
		void uzup_tab(int tab[9][9]);
		void skok_petla(int tab[9][9], int id, int jd, bool &don);
		int *zeruj_kr(int tab[9][9], int i, int j);
		void wykresl_do_rozw(int tab[9][9], int liczba);
		string odczyt_z_pl(string user);
		void zapis_do_pl(int tab[9][9], int number, string user);
	/*private:
		double x;
		double y;*/
};
