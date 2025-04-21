import React, { useEffect, useState, useRef } from 'react';
import { getDishes, put_updateAvailability } from '../../shared/services/dishService';
import { Pencil, Trash2, Plus, ChevronDown } from 'lucide-react';
import { useNavigate } from 'react-router-dom';

export default function DishList() {
  const [dishes, setDishes] = useState([]);
  const [openDropdownId, setOpenDropdownId] = useState(null);
  const dropdownRef = useRef(null);
  const navigate = useNavigate();

  useEffect(() => {
    const fetchDishes = async () => {
      const data = await getDishes();
      setDishes(data);
    };
    fetchDishes();
  }, []);

  useEffect(() => {
    const handleClickOutside = (event) => {
      if (
        dropdownRef.current &&
        !dropdownRef.current.contains(event.target)
      ) {
        setOpenDropdownId(null); 
      }
    };
  
    document.addEventListener('mousedown', handleClickOutside);
    return () => {
      document.removeEventListener('mousedown', handleClickOutside);
    };
  }, []);

  const handleEdit = (dishId) => {
    console.log("Editar prato com ID:", dishId);
    
  };

  const handleDelete = (dishId) => {
    console.log("Excluir prato com ID:", dishId);
    
  };

  const handleAdd = () =>{
    navigate('/kitchen/dishCreate');
  }

  const toggleDropdown = (dishId) => {
    setOpenDropdownId(openDropdownId === dishId ? null : dishId);
  };

  const updateAvaliability = async (id,aval) =>{
    var updatedDish = await put_updateAvailability(id, aval) 

    setDishes(prev =>
      prev.map(dish =>
        dish.id === id ? updatedDish : dish
      )
    );
  }
  

  return (
    <div className="p-6">
      <div className="flex justify-between items-center mb-6">
        <h2 className="text-2xl font-bold text-gray-800">🍽️ Gerenciar Cardápio</h2>
        <button
          type="button"
          onClick={handleAdd}
          className="flex items-center gap-2 text-white bg-green-700 hover:bg-green-800 focus:outline-none focus:ring-4 focus:ring-green-300 font-medium rounded-full text-sm px-5 py-2.5 dark:bg-green-600 dark:hover:bg-green-700 dark:focus:ring-green-800 cursor-pointer"
        >
          <Plus size={20} />
          Adicionar
        </button>
      </div>

      {dishes.length === 0 ? (
        <p className="text-gray-500">Nenhum prato encontrado.</p>
      ) : (
        <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-6">
          {dishes.map((dish) => (
            <div
              key={dish.id}
              className="bg-white border border-gray-200 shadow-sm rounded-xl p-4 relative"
            >
              <div className="flex justify-between items-start">
                <h3 className="text-lg font-semibold text-gray-900">{dish.name}</h3>

                <div className="flex gap-2">
                  <button
                    onClick={() => handleEdit(dish.id)}
                    className="p-1 rounded hover:bg-gray-100 cursor-pointer"
                    title="Editar"
                  >
                    <Pencil size={18} className="text-blue-500" />
                  </button>
                  <button
                    onClick={() => handleDelete(dish.id)}
                    className="p-1 rounded hover:bg-gray-100 cursor-pointer"
                    title="Excluir"
                  >
                    <Trash2 size={18} className="text-red-500" />
                  </button>
                </div>
              </div>

              <p className="text-gray-600 mt-2">
                {dish.description || "Sem descrição"}
              </p>

              <p className="text-green-600 font-bold mt-2 mb-4">
                {dish.price ? `R$ ${dish.price.toFixed(2)}` : "Preço não informado"}
              </p>


              <button
                    onClick={() => toggleDropdown(dish.id)}

                    className={`cursor-pointer text-sm flex items-center px-7 py-1.5 rounded 
                      ${dish.avaliable ? 'bg-green-700 hover:bg-green-800'  : 'bg-red-700 hover:bg-red-800'} 
                      text-white`}>
                      {dish.avaliable ? 'Disponivel'  : 'Indisponivel'} 
                     <ChevronDown size={16} className="ml-1" />
              </button>
              {openDropdownId === dish.id && (
                <div ref={dropdownRef} className="absolute top-12 right-4 z-10 bg-white border border-gray-200 rounded-lg shadow-md w-44">
                  <ul className="py-2 text-sm text-gray-700">
                    <li>
                      <a onClick={() => updateAvaliability(dish.id, true)} className="block px-4 py-2 cursor-pointer hover:bg-gray-100">Disponivel</a>
                    </li>
                    <li>
                      <a onClick={() => updateAvaliability(dish.id, false)} className="block px-4 py-2 cursor-pointer hover:bg-gray-100">Indisponivel</a>
                    </li>
                  </ul>
                </div>
              )}


            </div>
          ))}
        </div>
      )}
    </div>
  );
}
