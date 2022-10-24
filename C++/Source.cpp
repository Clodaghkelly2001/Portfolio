#include <iostream>
using namespace std;
#include <string>

int main()
{
	int number{};
	string names{};
	int counter{};


	cout << "How many names do you want to enter" << endl;
	cin >> number;

	string *list = new(std::nothrow) string[number] {};

	string *number = new string[number] {};
	string *list = new string[2*number];

	for (int i = 0; i < number; i++)
	{
		list[i] = number[i];
	}
	delete[]number;
	list = number;

	list = nullptr;
	// print the end result
	for (int i = 0; i < 5; i++)
	{
		std::cout << number[i] << std::endl;
	}

	for (int i{ 0 }; i < number; i++)
	{
		cout << "Please enter a name" << (counter + 1) << endl;
		cin >> names;
		*(list + i) = names;
		counter++;
	}

	for (int i{ 0 }; i < number; i++)
	{
		cout << "\n" << "Name: " << (i + 1) << ": " << list[i] << endl; 
	}

	return 0;
}
