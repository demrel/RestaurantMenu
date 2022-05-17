import './App.css';
import React, { Suspense, lazy } from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import {
  Box,
  Container
} from '@chakra-ui/react'
import { Header } from './layouts'

const Home = lazy(() => import('./pages/Home'));
const Category = lazy(() => import('./pages/Category'));
const Product = lazy(() => import('./pages/Product'));
const UpdateCategory =lazy(() => import('./pages/UpdateCategory'));
const UpdateProduct =lazy(() => import('./pages/UpdateProduct'));


const App = () => {
  return (
    <>
      <Header />
      <Router>
        <Suspense fallback={<div>Loading...</div>}>
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="category" element={<Category />} />
            <Route path="category/edit/:id" element={<UpdateCategory />} />
            <Route path="product" element={<Product />} />
            <Route path="product/edit/:id" element={<UpdateProduct />} />
          </Routes>
        </Suspense>
      </Router>
    </>
  );
}

export default App;


