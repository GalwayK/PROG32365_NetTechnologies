/* Murtaza Mian
 * 991635342
 * Sheridan College
 * Assignment 2 */

#include <stdio.h>
#include <stdlib.h>

#define ERROR_CHECK \
	if (!head || !*head) { \
		printf("\n\nThere are no nodes. Returning...\n"); \
		return; \
	}

#define INSERT_CHECK \
	if (!head || !*head) { \
		int num; \
		printf("\n\nThere are no nodes. Creating new list.\nEnter num:"); \
		scanf("%d", &num); \
		*head = create_node(num); \
		return; \
	}
#define PROMPT \
	int n; \
	printf("\nEnter the data for the node: "); \
	while (scanf("%d", &n) != 1) { \
		printf("Invalid input. Please enter an integer.\n"); \
		while (getchar() != '\n'); \
		printf("Enter the data for the node: "); \
	} \

struct node {
	int value; // unspecified in assignment, use standard int
	struct node *next;
};

struct node *create_node(int n)
{
	struct node *new_node = malloc(sizeof(struct node));
	if (!new_node) { 
		printf("Ran out of memory. Exiting ..."); 
		exit(EXIT_FAILURE); 
	}
	new_node->value = n;
	new_node->next = NULL;
	return new_node;
}

void print_list(struct node *head)
{
	if (!head) { 
		printf("\n\nThere are no nodes. Returning...\n\n");
		return;
	}
	int count = 1;
	while (head) {
		printf("\nData at %d  --%8d",
			count++, head->value);
		head = head->next;
	}
}

void insert_at_first(struct node **head)
{
	INSERT_CHECK;
	PROMPT;
	struct node *new_node = create_node(n);
	new_node->next = *head;
	*head = new_node; 
}

void insert_anywhere(struct node **head)
{
	INSERT_CHECK;
	print_list(*head);
	int place; 
	printf("\nWhat node would you like to place your new node after?: "); 
	while (scanf("%d", &place) != 1) { 
		printf("Invalid input. Please enter an integer.\n"); 
		while (getchar() != '\n'); 
		printf("\nWhat node would you like to place your new node after?: "); 
	}
	PROMPT;
	struct node *new_node = create_node(n);
	struct node *tmp = *head;
	for (int i = 1; i < place; i++)
		tmp = tmp->next;
	new_node->next = tmp->next;
	tmp->next = new_node;
}

void insert_at_last(struct node **head)
{
	INSERT_CHECK;
	PROMPT;
	struct node *new_node = create_node(n);
	struct node *tmp = *head;
	while (tmp->next != NULL)
		tmp = tmp->next;
	tmp->next = new_node;
}


void delete_first(struct node **head)
{
	ERROR_CHECK;
	struct node *p = (*head); 	// current head in temp 
	*head = (*head)->next; 		// update head to next node
	free(p); 			// free original node
}

void delete_last(struct node **head)
{
	ERROR_CHECK;
	struct node **p = head;
	while ((*p)->next != NULL)
		p = &(*p)->next;
	*p = NULL;
	free(*p);
}


void delete_from_list(struct node **head)
{
	ERROR_CHECK;
	PROMPT;
	struct node **p = head, *tmp = NULL;
	while (*p != NULL && (*p)->value != n)
		p = &(*p)->next, tmp = *p;
	if (!(*p)) {
		printf("\nThis node does not exist. Returning.\n");
		return;
	}
	*p = (*p)->next;
	free(tmp);
}

void search(struct node *head)
{
	if (!head)
		return;
	int n, pos = 1;
	printf("\nWhat number are you looking for?: ");
	while (scanf("%d", &n) != 1) { 
		printf("Invalid input. Please enter an integer.\n"); 
		while (getchar() != '\n'); 
		printf("\nWhat number are you looking for?: "); 
	}
	while (head->next != NULL && head->value != n)
		head = head->next, pos++;
	if (head->value != n) { 
		printf("This value is not in the list\n");
		return;
	}
	printf("This value is in the list! It is in position %d\n", pos);
}

void intro_helper(struct node **head, int n)
{
	struct node *new_node = create_node(n);
	struct node *tmp = *head;
	while (tmp->next != NULL)
		tmp = tmp->next;
	tmp->next = new_node;
}

void intro(struct node **head) {
	int i = 1, value;
	char choice;
	while (1) {
		printf("Enter the data for node %d: ", i);
		if (scanf("%d", &value) != 1) { // Input handling
			printf("Invalid input. Please enter an integer.\n");
			while (getchar() != '\n'); // Clear input buffer
			continue; // Skip
		}
		while (getchar() != '\n'); 

		if (*head == NULL)
			*head = create_node(value);
		else
			intro_helper(&(*head), value);

		do {
			printf("\nEnter more <y>es/<n>o ?: ");
			scanf(" %c", &choice);
			while (getchar() != '\n'); 

			if (choice != 'y' && choice != 'Y' && choice != 'n' && choice != 'N') 
				printf("Invalid input. Please enter 'y' or 'n'.\n");
		} while (choice != 'y' && choice != 'Y' && choice != 'n' && choice != 'N');

		if (choice == 'n' || choice == 'N')
			break; 
		i++;
	}
}

void output()
{
	printf("\n\t===============\n"); 
	printf("\t1) Display List\n"); // DONE
	printf("\t2) Insert First\n"); // DONE
	printf("\t3) Insert Last\n"); // DONE
	printf("\t4) Insert Anywhere\n"); // DONE
	printf("\t5) Delete First\n"); // DONE
	printf("\t6) Delete Last\n"); // DONE
	printf("\t7) Delete Anyone\n"); // DONE
	printf("\t8) Search\n"); // DONE
	printf("\t0) Exit\n"); // DONE
	printf("\tEnter your choice: ");
}

void free_list(struct node *head)
{
	if (!head)
		return;
			
	struct node *tmp;
	while (head) {
		tmp = head;
		head = head->next;
		free(tmp);
	}

	
}

int main()
{
	// populate first node
	struct node *head = NULL;
	int choice = 100;;
	intro(&head);

	do {
		output();
		if (scanf("%d", &choice) != 1) { // Input handling
			printf("Invalid input. Please enter an integer.\n");
			while (getchar() != '\n'); // Discard remaining input
			continue; // Skip 
		}

		switch(choice) {
		case 1:
			print_list(head);
			break;
		case 2:
			insert_at_first(&head);
			break;
		case 3:
			insert_at_last(&head);
			break;
		case 4:
			insert_anywhere(&head);
			break;
		case 5:
			delete_first(&head);
			break;
		case 6:
			delete_last(&head);
			break;
		case 7:
			delete_from_list(&head);
			break;
		case 8:
			search(head);
			break;
		case 0:
			printf("Goodbye\n");
			break;
		default:
			printf("invalid Choice");
			break;
		}
	} while (choice != 0);

	free_list(head);
	return 0;
}

//old stuff
//do {
//	printf("Enter the data for node %d: ", i);
//	if (scanf("%d", &value) != 1) { // Input handling
//		printf("Invalid input. Please enter an integer.\n");
//		while (getchar() != '\n'); // Discard remaining input
//		continue; // Skip 
//	}

//	if (*head == NULL)
//		*head = create_node(value);
//	else
//		intro_helper(&(*head), value);
//	i++;

//	printf("\nEnter more <y>es/<n>o ?: ");
//	scanf(" %c", &choice);
//	while (getchar() != '\n'); 

//} while (choice == 'y' || choice == 'Y');
