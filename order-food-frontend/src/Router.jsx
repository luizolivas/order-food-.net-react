import React from 'react';
import { Route, Routes } from 'react-router-dom';
import FoodPanel from './kitchen/pages/FoodPanel';

const AppRouter = () => {
    return (
      <Routes>
        <Route path="/kitchen/foodList" element={<FoodPanel />} />
      </Routes>
    );
  };

export default AppRouter;