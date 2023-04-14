import { Index } from './pages/index'
import { About } from './pages/about'
import { Contact } from './pages/contact'
import { Categories } from './pages/categories'
import { Login } from './pages/login'
import { Register } from './pages/register'
import { Write } from './pages/write'
import { Routes, Route } from "react-router-dom";

export default function App() {
  return (
    <Routes>
      <Route path="/" element={<Index />} />
      <Route path="/sobre" element={<About />} />
      <Route path="/contato" element={<Contact />} />
      <Route path="/categories" element={<Categories />} />
      <Route path="/login" element={<Login />} />
      <Route path="/register" element={<Register />} />
      <Route path="/write" element={<Write />} />
    </Routes>
  );
}

