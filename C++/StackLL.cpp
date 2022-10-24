#include <iostream>

struct Node {
    int data;
    Node* next;
};

Node* head;

void push(int x)
{
    // Create new node temp and allocate memory in heap
    Node* temp = new Node();
    temp->data = x;

    // insert element at the top of stack
    temp->next = head;
    head = temp; // new node as head of Stack
}


void pop()
{
    Node* temp;

    // Assign head to temp
    temp = head;

    // Assign second node to head
    head = head->next;

    delete(temp); // delete node from the memory
}

void print() {
    Node* temp = head; // start from the head

    // loop until we find the last element which always points to null
    while (temp != nullptr) {
        std::cout << temp->data << std::endl;
        temp = temp->next;
    }
}

int main()
{
    head = NULL; // "create" stack


    // Example of a stack with size 10 
    int size = 10;

    std::cout << "Pushing elements : " << std::endl;
    for (int i = 0; i < size; i++)
    {
        push(i * i + 5);
        std::cout << "Stack Head : " << head->data << std::endl;
    }

    std::cout << "\nPopping elements: " << std::endl;
    for (int i = 0; i < size - 1; i++)
    {
        std::cout << "Stack Head : " << head->data << std::endl;
        pop();
    }

    return 0;
}
