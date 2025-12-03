#include <stdio.h>
#include <stdlib.h>

struct LinkedList
{
    struct Node* head;
};

struct Node
{
    int value;
    struct Node* next;
};

struct Node* createNode(int value){
    struct Node* newNode = (struct Node*)malloc(sizeof(struct Node));
    newNode->value = value;
    newNode->next = NULL;
}

void insert(int value, struct LinkedList* ll){
    if(ll->head == NULL){
        struct Node* newNode = createNode(value);

        ll->head = newNode;
        return;
    }
    
    struct Node* tmp = ll->head;
    if(tmp->value >= value){
        ll->head = createNode(value);
        ll->head->next = tmp; 
        return;
    }
    else{
        while (tmp->next != NULL && tmp->next->value < value)
        {
            tmp = tmp->next;
        }

        struct Node* newNode = createNode(value);

        newNode->next = tmp->next;
        tmp->next = newNode;
    }

    return;
}

void printll(struct LinkedList* ll){
    struct Node* tmp = ll->head;
    while (tmp->next != NULL)
    {
        printf("%d -> ", tmp->value);
        tmp = tmp->next;
    }

    printf("%d", tmp->value);
    return;
}

int main(int argc, char const *argv[])
{
    // struct Node* node = createNode(5);
    // printf("%d", node->value);

    struct LinkedList* ll = (struct LinkedList*)malloc(sizeof(struct LinkedList));
    ll->head = NULL;
    insert(5, ll);
    insert(6, ll);
    insert(8, ll);
    insert(7, ll);
    insert(4, ll);
    printll(ll);

    free(ll);
    return 0;
}
