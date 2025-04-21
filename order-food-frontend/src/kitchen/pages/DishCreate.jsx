import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { post_createDish } from '../../shared/services/dishService';

export default function DishCreate() {
  const [dish, setDish] = useState({
    name: '',
    description: '',
    price: '',
    avaliable: false,
    categoryId: 1
  });

  const navigate = useNavigate();

  const handleChange = (e) => {
    const { name, value } = e.target;
    setDish({ ...dish, [name]: value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    await post_createDish({ ...dish, price: parseFloat(dish.price) });
    navigate('/kitchen/dishList'); 
  };

  const isFormFilled = () => {
    return dish.name || dish.description || dish.price;
  };

  const backToList = () =>{
    if (isFormFilled()) {
        const confirm = window.confirm("Se voltar agora, os dados preenchidos serão perdidos. Deseja continuar?");
        if (!confirm) return;
      }
    
      navigate('/kitchen/dishList');
  }

  return (
    <div className="p-6 max-w-lg mx-auto">
      <h2 className="text-2xl font-bold mb-4">🍽️ Criar Novo Prato</h2>
      <form onSubmit={handleSubmit} className="space-y-4">
        <input
          type="text"
          name="name"
          placeholder="Nome"
          value={dish.name}
          onChange={handleChange}
          className="w-full border p-2 rounded"
          required
        />
        <textarea
          name="description"
          placeholder="Descrição"
          value={dish.description}
          onChange={handleChange}
          className="w-full border p-2 rounded"
        />
        <input
          type="number"
          name="price"
          placeholder="Preço"
          value={dish.price}
          onChange={handleChange}
          className="w-full border p-2 rounded"
          required
        />
        <div className="flex items-center gap-2">
        <input
            type="checkbox"
            name="avaliable"
            checked={dish.avaliable}
            onChange={(e) =>
            setDish({ ...dish, avaliable: e.target.checked })
            }
            className="w-4 h-4"
        />
        <label className="text-sm text-gray-700">Já disponível para venda</label>
        </div>
        <button
          type="submit"
          className="bg-green-600 hover:bg-green-700 text-white px-4 py-2 rounded cursor-pointer"
        >
          Criar
        </button>
        <button
          type="button"
          onClick={backToList}
          className="bg-yellow-400 hover:bg-yellow-500 ml-2.5 text-white px-4 py-2 rounded cursor-pointer"
        >
          Voltar
        </button>

      </form>
    </div>
  );
}
