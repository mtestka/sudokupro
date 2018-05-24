#pragma once

#include "header.h"
#include <iostream>
#include <ctime>
#include <string>
#include <cstdlib>
#include <fstream>
#include <cmath>

using namespace std;

myClass::myClass() {

}

/*double myClass::sumX_Y() {
	return x + y;
}*/

void myClass::uzup_tab(int tab[9][9]) {
	for (int i = 0; i< 9; i++) {
		for (int j = 0; j < 9; j++) {
			tab[i][j] = 0;
		}
	}
}

int* myClass::zeruj_kr(int tab[9][9], int i, int j) {
	int *acc = new int[9];
	for (int a = 0; a<9; a++) {
		acc[a] = a + 1;
	}
	int pw = i / 3, pk = j / 3;
	for (int p = 3 * pw; p<3 * pw + 3; p++) {
		for (int r = 3 * pk; r<3 * pk + 3; r++) {
			if (tab[p][r] != 0) {
				acc[tab[p][r] - 1] = 0;
			}
		}
	}
	for (int b = 0; b<9; b++) {
		if (tab[i][b] != 0) {
			acc[tab[i][b] - 1] = 0;
		}
	}
	for (int b = 0; b<9; b++) {
		if (tab[b][j] != 0) {
			acc[tab[b][j] - 1] = 0;
		}
	}
	return acc;
}

void myClass::skok_petla(int tab[9][9], int id, int jd, bool &don) {
	for (int i = id; i < id + 3; i++) {
		for (int j = jd; j<jd + 3; j++) {
			if (tab[i][j] == 0) {
				don = false;
				for (int g = 0; g<9; g++) {
					if (zeruj_kr(tab, i, j)[g] != 0) {
						don = true;
					}
				}
				if (!don) {
					return;
				}
				int b = 0;
				int cc = rand() % 9;
				while (b == 0) {
					b = zeruj_kr(tab, i, j)[cc];
					//idx = cc;
					cc = rand() % 9;
				}
				//zeruj_kr(tab, i,j)[idx] = 0;
				tab[i][j] = b;
			}
		}
	}
}

void myClass::wykresl_do_rozw(int tab[9][9], int liczba) {
	int i = 0;
	while (i < liczba) {
		int a = rand() % 9;
		int b = rand() % 9;
		if (tab[a][b] != 0) {
			tab[a][b] = 0;
			i++;
		}
	}
}

string myClass::odczyt_z_pl(string user) {
	ifstream odczyt("C:/Users/" + user + "/Desktop/plansze.txt");
	string znaki = "";
	if (odczyt.is_open())
	{
		char znak;
		while (odczyt >> znak)
		{
			znaki += znak;
		}
	}
	else
		cout << "Nie uda³o siê otworzyæ pliku";
	return znaki;
}

void myClass::zapis_do_pl(int tab[9][9], int number, string user) {
	ofstream zapis("C:/Users/" + user + "/Desktop/plansze.txt", ios_base::app);
	zapis << "Generated board : No. " << number << endl << endl;
	for (int i = 0; i < 9; i++) {
		for (int j = 0; j<9; j++) {
			zapis << tab[i][j] << "  ";
			if ((j + 1) % 3 == 0) {
				zapis << "  ";
			}
		}
		if ((i + 1) % 3 == 0) {
			zapis << endl;
		}
		zapis << endl;
	}
	zapis << endl << endl;
	zapis.close();
}