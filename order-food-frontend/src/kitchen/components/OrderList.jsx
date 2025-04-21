import React, { useEffect, useState } from 'react';
import { getDishes } from '../../shared/services/dishService';
import { Pencil, Trash2 } from 'lucide-react';

export default function OrderList() {
  const [orders, setOrders] = useState([]);

  useEffect(() => {
    const fetchOrders = async () => {
      const data = await getDishes();
      setOrders(data);
    };
    fetchOrders();
  }, []);

  const handleEdit = (dishId) => {
    console.log("Editar prato com ID:", dishId);
    
  };

  const handleDelete = (dishId) => {
    console.log("Excluir prato com ID:", dishId);
    
  };

  return (
    <div className="p-6">
      <h2 className="text-2xl font-bold text-gray-800 mb-6">🍽️ Gerenciar Cardápio</h2>

      {orders.length === 0 ? (
        <p className="text-gray-500">Nenhum prato encontrado.</p>
      ) : (
        <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-6">
          {orders.map((dish) => (
            <div
              key={dish.id}
              className="bg-white border border-gray-200 shadow-sm rounded-xl p-4 relative"
            >
              <div className="flex justify-between items-start">
                <h3 className="text-lg font-semibold text-gray-900">{dish.name}</h3>

                <div className="flex gap-2">
                  <button
                    onClick={() => handleEdit(dish.id)}
                    className="p-1 rounded hover:bg-gray-100"
                    title="Editar"
                  >
                    <Pencil size={18} className="text-blue-500" />
                  </button>
                  <button
                    onClick={() => handleDelete(dish.id)}
                    className="p-1 rounded hover:bg-gray-100"
                    title="Excluir"
                  >
                    <Trash2 size={18} className="text-red-500" />
                  </button>
                </div>
              </div>

              <p className="text-gray-600 mt-2">
                {dish.description || "Sem descrição"}
              </p>

              <p className="text-green-600 font-bold mt-2">
                {dish.price ? `R$ ${dish.price.toFixed(2)}` : "Preço não informado"}
              </p>
            </div>
          ))}
        </div>
      )}
    </div>
  );
}
