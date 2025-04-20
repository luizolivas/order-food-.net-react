import { Outlet } from 'react-router-dom';
import NavbarKitchen from './components/NavbarKitchen';

export default function KitchenLayout() {
  return (
    <div className="w-full min-h-screen bg-gradient-to-br from-sky-200 to-indigo-200 flex flex-col">
      <NavbarKitchen />
      <main className="flex-1 p-6">
        <div className="bg-white/40 backdrop-blur-md p-6 rounded-xl shadow-xl max-w-5xl mx-auto">
          <Outlet />
        </div>
      </main>
    </div>
  );
}
