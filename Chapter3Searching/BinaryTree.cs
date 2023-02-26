namespace Course.Chapter3Searching; 

public class BinaryTree<TKey, TValue> : ISymbolTable<TKey, TValue> {
    private Node _root = null;

    public void Add(TKey key, TValue value) {
        if (_root == null) {
            _root = new Node {
                Key = key,
                Value = value
            };
            return;
        }

        var currentNode = _root;
        while (true) {
            var compare = Comparer<TKey>.Default.Compare(key, currentNode.Key);
            if (compare == 0) {
                throw new ArgumentException();
            }

            if (compare == -1) {
                if (currentNode.LeftChild != null) {
                    currentNode = currentNode.LeftChild;
                    continue;
                }

                currentNode.LeftChild = new Node {
                    Parent = currentNode,
                    Key = key,
                    Value = value
                };

                return;
            }

            if (currentNode.RightChild != null) {
                currentNode = currentNode.RightChild;
                continue;
            }

            currentNode.RightChild = new Node {
                Parent = currentNode,
                Key = key,
                Value = value
            };
                
            return;
        }
    }

    public bool Contains(TKey key) {
        if (_root == null) {
            return false;
        }

        var currentNode = _root;
        while (true) {
            var compare = Comparer<TKey>.Default.Compare(key, currentNode.Key);
            if (compare == 0) {
                return true;
            }

            if (compare == -1) {
                if (currentNode.LeftChild != null) {
                    currentNode = currentNode.LeftChild;
                    continue;
                }

                return false;
            }

            if (currentNode.RightChild != null) {
                currentNode = currentNode.RightChild;
                continue;
            }
                
            return false;
        }
    }

    public bool Remove(TKey key) {
        if (_root == null) {
            return false;
        }

        var currentNode = _root;
        while (true) {
            var compare = Comparer<TKey>.Default.Compare(key, currentNode.Key);
            if (compare == 0) {
                break;
            }

            if (compare == -1) {
                if (currentNode.LeftChild != null) {
                    currentNode = currentNode.LeftChild;
                    continue;
                }

                return false;
            }

            if (currentNode.RightChild != null) {
                currentNode = currentNode.RightChild;
                continue;
            }
                
            return false;
        }

        // TODO

        return true;
    }

    public TValue Get(TKey key) {
        if (_root == null) {
            throw new ArgumentOutOfRangeException();
        }

        var currentNode = _root;
        while (true) {
            var compare = Comparer<TKey>.Default.Compare(key, currentNode.Key);
            if (compare == 0) {
                return currentNode.Value;
            }

            if (compare == -1) {
                if (currentNode.LeftChild != null) {
                    currentNode = currentNode.LeftChild;
                    continue;
                }

                throw new ArgumentOutOfRangeException();
            }

            if (currentNode.RightChild != null) {
                currentNode = currentNode.RightChild;
                continue;
            }
                
            throw new ArgumentOutOfRangeException();
        }
    }

    private class Node {
        public Node Parent;
        public Node LeftChild;
        public Node RightChild;

        public TKey Key;
        public TValue Value;
    }
}