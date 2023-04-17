import { Index } from './pages/index'
import { About } from './pages/about'
import { Contact } from './pages/contact'
import { Categories } from './pages/categories'
import { Routes, Route } from "react-router-dom";

export default function App() {
  return (
    <Routes>
      <Route path="/" element={<Index />} />
      <Route path="/sobre" element={<About />} />
      <Route path="/contato" element={<Contact />} />
      <Route path="/categories" element={<Categories />} />
    </Routes>
  );
}

