#include <iostream>

struct Node {
    int data;
    Node* next;
};

Node* head, * tail;

void enQueue(int x)
{
    // Create a new node
    Node* temp = new Node;
    temp->data = x;
    temp->next = NULL;

    // If queue is empty, the new node is head and tail 
    if (tail == NULL) {
        head = tail = temp;
        return;
    }

    // Insert new node at the end of queue
    tail->next = temp;
    tail = temp;
}

void deQueue()
{
    // If queue is empty, return NULL.
    if (head == NULL)
        return;

    // Store previous head and move head one node ahead
    Node* temp = head;
    head = head->next;

    // If head becomes NULL, then tail is also NULL
    if (head == NULL)
        tail = NULL;


    delete (temp); // delete node from the memory
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

    head = tail = NULL; // "create" queue


    // Example of a queue with size 10 
    int size = 10;

    std::cout << "Enqueue : " << std::endl;
    for (int i = 0; i < size; i++)
    {

        enQueue(i * i);

        std::cout << "Queue Head : " << head->data << " ::::: Tail : " << tail->data << std::endl;
    }

    std::cout << "\nDequeue : " << std::endl;
    for (int i = 0; i < size - 1; i++)
    {

        deQueue();

        std::cout << "Queue Head : " << head->data << " ::::: Tail : " << tail->data << std::endl;
    }

}
