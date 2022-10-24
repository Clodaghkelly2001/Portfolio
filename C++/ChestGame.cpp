#include <iostream>
#include <vector>

using namespace std;

/*
   Random string generator
*/
const int ch_MAX = 26; // total number of letters in the alphabet
string RandomString(int str_lenght)
{
    char alpha[ch_MAX] = { 'a', 'b', 'c', 'd', 'e', 'f', 'g',
                          'h', 'i', 'j', 'k', 'l', 'm', 'n',
                          'o', 'p', 'q', 'r', 's', 't', 'u',
                          'v', 'w', 'x', 'y', 'z' };
    string result = "";
    for (int i = 0; i<str_lenght; i++)
        result = result + alpha[rand() % ch_MAX];
    return result;
}

/*
    Struct Item holding information about items
*/
struct Item
{
    // name of the item
    //  value of the item
};

class Chest { 
     vector<Item> items; // vector to store items
    int cursedItemChance; // chances of getting a cursed item
    public:
        Chest(int n_items); // constructor
        bool removeItem(Item &item);
        bool isEmpty();
    private:
        void addItem(Item item);
        bool calculateCursedItemChance();

};

// class constructor
Chest::Chest(int n_items=10){ 

    cursedItemChance = 0; // start with a 0% chance of finding the cursed item

    // add 10 random items to the box
    for (size_t i = 0; i < n_items; i++)
    {
        // create new item and assign a random name and a random value
        /*
            your code

            // item name will be a random string from the RandomString() function
            // random number between 0 and 50
        */

        // add new item to the chest
        /*
            your code
        */
    }
}

// add a new item to Chest
void Chest::addItem(Item item){
    items.push_back(item);
}

// remove item from chest 
bool Chest::removeItem(Item &item){
    // raise the odds of this being a cursed item
    if(calculateCursedItemChance()){
        return false;
    }

    // get a random vector index by using the module operator
    int randomIndex = rand() % items.size();


    // find item by index using the at() method
    /*
        insert your code here
    */


    item.value *= 1+cursedItemChance; // the value of the item increases after each turn based on the odds of getting a cursed item


    // remove item from vector (the erase() method uses a pointer to the first position of the vector plus the index position of the element we want to find)
    /*
        insert your code here
    */

    cursedItemChance +=5; //increases the chance of finding a cursed item by 5%
    
    return true;
}

bool Chest::isEmpty(){
    return items.empty();
}

bool Chest::calculateCursedItemChance(){

    int randomIndex = rand() % 100;
    return randomIndex < cursedItemChance;
}


int main () {
    srand(time(NULL));
    char guess;

    int player_gold = 0;

    Chest items; // create new object from Chest class

    cout << "You received a mystery chest with 10 items,\
    every time you take an item from this chest there is a chance of being cursed and lose you life!\
    How much do you want to risk?" <<  endl;


    // open the box...    
    while (!items.isEmpty())
    {
         cout << "\n\nTake a new item? (y/n): ";
        // Take user input 
         cin >> guess;
        if (guess == 'y')
        {
            //get random item from box 
            Item randomItem;
            if(items.removeItem(randomItem))
            {
                // print item details
                cout << randomItem.name << " was found\n";

                player_gold += randomItem.value;

                cout<< "Player Networth: " << player_gold << endl;
                continue;
            } 
            cout<< "You are now cursed!\n\n";
            break;      
        }
        else if(guess == 'n'){
            cout<< "Left with: " << player_gold << endl;
            break;
        }   
    }
}
