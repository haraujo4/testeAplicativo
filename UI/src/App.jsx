import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import { AtendimentoProvider } from './context/AtendimentoContext';
import Menu from './components/Menu';
import Pacientes from './pages/Pacientes';
import Triagem from './pages/Triagem';
import Painel from './pages/Painel';
import ToastContainer from './components/ToastContainer';

const App = () => {
  return (
    <AtendimentoProvider>
      <Router>
        <Menu />
        <ToastContainer />
        <Routes>
          <Route path="/" element={<h1>Bem-vindo ao Atendimento Clínico</h1>} />
          <Route path="/pacientes" element={<Pacientes />} />
          <Route path="/triagem" element={<Triagem />} />
          <Route path="/painel" element={<Painel />} />
        </Routes>
      </Router>
    </AtendimentoProvider>
  );
};

export default App;
