#include <stdio.h>
#include <stdlib.h>

#define MAX 5  // Define the maximum size of the queue

typedef struct {
    int items[MAX];
int front;
int rear;
} Queue;


void initializeQueue(Queue* q)
{
    q->front = -1;
    q->rear = -1;
}


int isFull(Queue* q)
{
    if (q->rear == MAX - 1)
        return 1;
    return 0;
}


int isEmpty(Queue* q)
{
    if (q->front == -1 || q->front > q->rear)
        return 1;
    return 0;
}


void enqueue(Queue* q, int value)
{
    if (isFull(q))
    {
        printf("Queue is full. Cannot enqueue %d\n", value);
    }
    else
    {
        if (q->front == -1)
            q->front = 0;
        q->rear++;
        q->items[q->rear] = value;
        printf("%d enqueued to the queue\n", value);
    }
}


int dequeue(Queue* q)
{
    int item;
    if (isEmpty(q))
    {
        printf("Queue is empty. Cannot dequeue\n");
        return -1;
    }
    else
    {
        item = q->items[q->front];
        q->front++;
        if (q->front > q->rear)
        {
            q->front = q->rear = -1;  
        }
        return item;
    }
}


void displayQueue(Queue* q)
{
    if (isEmpty(q))
    {
        printf("Queue is empty\n");
    }
    else
    {
        printf("Queue elements: ");
        for (int i = q->front; i <= q->rear; i++)
        {
            printf("%d ", q->items[i]);
        }
        printf("\n");
    }
}

int main()
{
    Queue q;
    initializeQueue(&q);

    enqueue(&q, 10);
    enqueue(&q, 20);
    enqueue(&q, 30);
    enqueue(&q, 40);
    enqueue(&q, 50);
    enqueue(&q, 60);  

    displayQueue(&q);

    printf("Dequeued: %d\n", dequeue(&q));
    printf("Dequeued: %d\n", dequeue(&q));

    displayQueue(&q);

    return 0;
}
