#include <iostream>
#include <cstdlib>

using namespace std;

int main(int argc, char* argv[])
{
#ifdef _WIN32
	if (argc > 0)
	{
		//cout << argv[0] << endl << argv[1] << endl;
		string arg = argv[1];
		if (arg == "-prepop")
		{
			cout << "Running WinSAT prepop.." << endl;
			system("winsat prepop");
			system("pause");
		}
	}
	else
	{
		cout << "No arguments provided, use -help to list available commands" << endl;
		system("pause");
		return -1;
	}
#elif
	cout << "ERROR: Not being run under Win32, exiting" << endl;
	return -3;
#endif
}