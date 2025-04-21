import React from 'react';
import { Link } from 'react-router-dom';

export default function NavbarKitchen() {
  return (
    <nav className="bg-gray-800 text-white px-6 py-4 shadow-md">
      <div className="flex justify-between items-center">
        <h1 className="text-xl font-bold">🍽️ Painel da Cozinha</h1>
        <div className="space-x-4">
          {/* <Link to="/" className="hover:underline">Início</Link> */}
          <Link to="/kitchen/dishList" className="hover:underline">Pratos</Link>
          <Link to="/kitchen/orderList" className="hover:underline">Pedidos</Link>
        </div>
      </div>
    </nav>
  );
}
