import React from 'react';
import { Route, Routes } from 'react-router-dom';
import KitchenLayout from './kitchen/KitchenLayout';
import DishPanel from './kitchen/pages/DishPanel';

const AppRouter = () => {
    return (
      <Routes>
        <Route path="/kitchen" element={<KitchenLayout />}>
          <Route path="dishList" element={<DishPanel />} />
        </Route>
      </Routes>
    );
  };

export default AppRouter;