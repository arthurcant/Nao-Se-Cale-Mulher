import { Index } from './pages/index'
import { About } from './pages/about'
import { Contact } from './pages/contact'
import { Categories } from './pages/categories'
import { Login } from './pages/login'
import { Register } from './pages/register'
import { Write } from './pages/write'
import { Routes, Route } from "react-router-dom";
import { useEffect, useState } from 'react'
  

export default function App() {

  const [itens, setItens] = useState ([])

  useEffect(() => {
    const fetchData = async () => {
      const result = await fetch('https://jsonplaceholder.typicode.com/todos')
        .then(response => response.json())
        .then(data => data)

     setItens(result)
    }
    fetchData()
  }, [])

  /*
  return (
    <div className='App'>
      {itens.map(itens => {
        return <div><span>item.id</span><span>item.title</span>item.completed<span></span></div>
      })}
    </div>
    );
  */

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

