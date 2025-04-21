import React from 'react';
import { Route, Routes, Navigate } from 'react-router-dom';
import KitchenLayout from './kitchen/KitchenLayout';
import DishPanel from './kitchen/pages/DishPanel';
import OrderPanel from './kitchen/pages/OrderPanel';
import DishCreate from './kitchen/pages/DishCreate';

const AppRouter = () => {
    return (
      <Routes>
        <Route path="/kitchen" element={<KitchenLayout />}>
          <Route index element={<Navigate to="orderList" replace />} />
          <Route path="dishList" element={<DishPanel />} />
          <Route path="dishCreate" element={<DishCreate />} />
          <Route path="orderList" element={<OrderPanel />} />        
        </Route>
      </Routes>
    );
  };

export default AppRouter;