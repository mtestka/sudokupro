#include "C:\\Users\\Public\\repos\\SudokuClass\\SudokuClass\\header.h"
#include "C:\\Users\\Public\\repos\\SudokuClass\\SudokuClass\\body.cpp"
#include <string>
using namespace std;

extern "C" _declspec(dllexport) void Uzup(int tab[9][9]) {
	myClass Mc;
	return Mc.uzup_tab(tab);
}

extern "C" _declspec(dllexport) int* Zeruj(int tab[9][9], int i, int j) {
	myClass Mc;
	return Mc.zeruj_kr(tab, i, j);
}

extern "C" _declspec(dllexport) void Skok(int tab[9][9], int id, int jd, bool &don) {
	myClass Mc;
	return Mc.skok_petla(tab, id, jd, don);
}

extern "C" _declspec(dllexport) void Wykresl(int tab[9][9], int liczba) {
	myClass Mc;
	return Mc.wykresl_do_rozw(tab, liczba);
}

extern "C" _declspec(dllexport) string Odczyt(string user) {
	myClass Mc;
	return Mc.odczyt_z_pl(user.c_str);
}

extern "C" _declspec(dllexport) void Zapis(int tab[9][9], int number, string user) {
	myClass Mc;
	return Mc.zapis_do_pl(tab, number, user.c_str);
}