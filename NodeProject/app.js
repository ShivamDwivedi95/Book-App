const path = require('path');
const express = require('express');
const app = express();
const cors = require('cors');
const PORT = process.env.PORT || 8080;

app.use(cors());

let books = [
  {
    id: 1,
    title: 'The Great Gatsby',
    author: 'F. Scott Fitzgerald'
  },
  {
    id: 2,
    title: 'To Kill a Mockingbird',
    author: 'Harper Lee'
  },
  {
    id: 3,
    title: "Two Men and the Sea",
    author: "Flamingo"
    },
    {
    id: 4,
    title: "Learn C++",
    author: "Sunanda Arora"
    }
];

app.use(express.json());

// GET all books
app.get('/books', (req, res) => {
  res.json(books);
});

// GET a single book by id
app.get('/books/:id', (req, res) => {
  const book = books.find(book => book.id === parseInt(req.params.id));
  if (!book) return res.status(404).send('Book not found');
  res.json(book);
});

// POST a new book
app.post('/books', (req, res) => {
  const book = {
    id: books.length + 1,
    title: req.body.title,
    author: req.body.author
  };
  books.push(book);
  res.json(book);
});

// PUT/update an existing book
app.put('/books/:id', (req, res) => {
  const book = books.find(book => book.id === parseInt(req.params.id));
  if (!book) return res.status(404).send('Book not found');
  book.title = req.body.title;
  book.author = req.body.author;
  res.json(book);
});

// DELETE a book by id
app.delete('/books/:id', (req, res) => {
  const book = books.find(book => book.id === parseInt(req.params.id));
  if (!book) return res.status(404).send('Book not found');
  const index = books.indexOf(book);
  books.splice(index, 1);
  res.json(book);
});

app.listen(PORT, () => console.log(`Server started on port ${PORT}`));
