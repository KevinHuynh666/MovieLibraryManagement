using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/**
 * This is the code of MovieCollection.
 * **/
namespace MovieManagement
{

    class MovieCollection
    {
        // Declare the private Root node to save the BST.
        private static Node Root = null;

        // BST node 
        public class Node
        {
            public Movie movie;
            public string title;
            public Node left, right;

        };
        // Function to create a new empty Node
        public static Node newNode(Movie data)
        {
            Node temp = new Node();

            temp.movie = data;
            temp.title = data.title;

            temp.left = null;
            temp.right = null;

            return temp;
        }

        // Find the height of BST
        static int getHeight(Node root)
        {
            if (root == null) return 0;

            int lh = getHeight(root.left);
            int rh = getHeight(root.right);
            return 1 + Math.Max(lh, rh);
        }

        // Find the top 10 most borrowed movie
        static Movie[] mostBorrow(Node root, ref Movie[] mvList)
        {
            if (root == null)
                return mvList;
            else
            {
                mvList = mostBorrow(root.left, ref mvList);
                int curr = root.movie.borrowTimes;
                for (int i = 0; i < mvList.Length; i++)
                {
                    if (mvList[i] == null)
                    {
                        mvList[i] = root.movie;
                        break;
                    }
                    else
                    {
                        if (mvList[i].borrowTimes < curr)
                        {
                            for (int j = mvList.Length - 1; j > i; j--)
                            {
                                mvList[j] = mvList[j - 1];
                            }
                            mvList[i] = root.movie;
                            break;
                        }
                    }
                }
                mvList = mostBorrow(root.right, ref mvList);
            }
            return mvList;
        }

        // Function to find top10, called from other files.
        public void top10()
        {
            int n = 10;
            int h = getHeight(Root);
            if (h < n) { n = h; }
            Movie[] resultList = new Movie[n + 1];
            Console.Clear();
            Console.WriteLine("===== Top 10 borrowed movies of all time =====");
            resultList = mostBorrow(Root, ref resultList);
            foreach (Movie i in resultList)
            {
                if (i != null)
                {
                    Console.WriteLine(i.title + " --- " + i.borrowTimes);
                }
            }
        }

        // Print the BST using In-order traversal
        static void Inorder(Node root)
        {
            if (root == null)
                return;
            else
            {
                Inorder(root.left);
                root.movie.showInfo();
                Inorder(root.right);
            }
        }

        // Function to print all info of all movies, called from other files.
        public void allInfo()
        {
            Console.Clear();
            Console.WriteLine("===== All DVD information ====");
            Inorder(Root);
        }


        // Find a movie given the title 
        static Movie findMovie(Node root, string title)
        {
            if (root == null)
                return null;
            else
            {
                if (root.movie.title == title)
                {
                    // Return the movie if the title is the same.
                    return root.movie;
                }
                Movie result = null;
                // If the current node is not the correct movie, find it on the left branch. 
                result = findMovie(root.left, title);
                if (result == null)
                {
                    // If it's not on the left branch, try to find the right branch
                    result = findMovie(root.right, title);
                }
                return result;
            }
        }

        // Function to find movie, called from other files
        public Movie find(string title)
        {
            Movie temp = null;
            temp = findMovie(Root, title);
            return temp;
        }

        // Insert into BST
        public static Node insert(Node root, Movie key)
        {
            // Create a new Node containing the new element 
            Node newnode = newNode(key);

            // Pointer to start traversing from root and 
            // traverses downward path to search 
            // where the new node to be inserted 
            Node x = root;

            // Pointer y maintains the trailing pointer of x 
            Node y = null;

            // Determine the Movie should be on the left or right branch using title to compare.
            while (x != null)
            {
                y = x;
                if (String.Compare(key.title, x.title) == -1)
                    x = x.left;
                else
                    x = x.right;
            }

            // If the root is null i.e the tree is empty, the new node is the root node
            if (y == null)
                y = newnode;

            // If the new key is less then the leaf node key, assign the new node to be its left child
            else if (String.Compare(key.title, y.title) == -1)
                y.left = newnode;

            // else assign the new node its right child 
            else
                y.right = newnode;
            if (Root == null) { Root = y; }
            // Returns the pointer where the new node is inserted 
            return y;
        }

        // Function to insert a movie, called from other files.
        public void Insert(Movie movie)
        {
            insert(Root, movie);
        }

        // Function to delete a movie, called from other files.
        public void removeMovie(string title)
        {
            if (find(title) != null)
            {
                Root = deleteRec(Root, title);
            }
            else
            {
                Console.WriteLine("Movie not found in libray. Return to main menu");
            }

        }

        // Delete the movie given the title
        Node deleteRec(Node root, string title)
        {

            // Base Case: If the tree is empty 
            if (root == null) return root;

            // Otherwise, recur down the tree 

            // Determine which branch should we continue to trace down.
            if (String.Compare(title, root.title) == -1)
                root.left = deleteRec(root.left, title);
            else if (String.Compare(title, root.title) == 1)
                root.right = deleteRec(root.right, title);

            // if title is same as root's title, then This is the node   to be deleted  
            else
            {
                // node with only one child or no child  
                if (root.left == null)
                    return root.right;
                else if (root.right == null)
                    return root.left;

                // node with two children: Get the inorder successor (smallest in the right subtree)
                  
                root.title = minValue(root.right);

                // Delete the inorder successor  
                root.right = deleteRec(root.right, root.title);
            }
            return root;
        }

        // Find the In-Order successor of a root
        string minValue(Node root)
        {
            string minv = root.title;
            while (root.left != null)
            {
                minv = root.left.title;
                root = root.left;
            }
            return minv;
        }

        // Constructor
        public MovieCollection()
        { Root = null; }

    }

}
