import React, { createContext, useState, useEffect } from 'react';
import axios from 'axios';

export const AtendimentoContext = createContext();

const api = axios.create({
  baseURL: 'http://localhost:5292' 
});

export const AtendimentoProvider = ({ children }) => {
  const [atendimentos, setAtendimentos] = useState([]);
  const [pacientes, setPacientes] = useState([]);
  const [especialidades, setEspecialidades] = useState([]);
  const [triagens, setTriagens] = useState([]); 
  const [atendendo, setAtendendo] = useState(null);

  const fetchPacientes = async () => {
    const response = await api.get('/api/paciente');
    setPacientes(response.data);
  };

  const fetchAtendimentos = async () => {
    try {
      const response = await api.get('/api/atendimento');
      console.log('Atendimentos obtidos:', response.data);
      setAtendimentos(response.data);
    } catch (error) {
      console.error('Erro ao buscar atendimentos:', error);
    }
  };

  const fetchEspecialidades = async () => {
    try {
      const response = await api.get('/api/especialidade');
      setEspecialidades(response.data);
    } catch (error) {
      console.error('Erro ao buscar especialidades:', error);
    }
  };

  const fetchTriagens = async () => {
    try {
      const response = await api.get('/api/triagem');
      setTriagens(response.data);
    } catch (error) {
      console.error('Erro ao buscar triagens:', error);
    }
  };

  const addPaciente = async (paciente) => {
    await api.post('/api/paciente', paciente);
    fetchPacientes();
  };

  const updatePaciente = async (paciente) => {
    await api.put(`/api/paciente/${paciente.id}`, paciente);
    fetchPacientes();
  }

  const addTriagem = async (triagem) => {
    try {
      const response = await api.post('/api/triagem', triagem);
      return response.data;
    } catch (error) {
      console.error('Erro ao cadastrar triagem:', error);
      throw error;
    }
  };

  const chamarPaciente = (id) => {
    const paciente = pacientes.find(p => p.id === id);
    setAtendendo(paciente);
    setPacientes(prev => prev.filter(p => p.id !== id));
  };

  const fetchPacienteByEmail = async (email) => {
    try {
      const response = await api.get(`/api/paciente/Email/${email}`);
      return response.data; 
    } catch (error) {
      console.error('Erro ao buscar paciente por e-mail:', error);
      return null; 
    }
  };

  useEffect(() => {
    fetchPacientes();
    fetchEspecialidades();
    fetchTriagens();
  }, []);

  return (
    <AtendimentoContext.Provider value={{ 
      pacientes, 
      especialidades, 
      triagens,
      addPaciente, 
      updatePaciente,
      fetchAtendimentos,
      addTriagem,
      chamarPaciente, 
      fetchPacienteByEmail, 
      atendendo 
    }}>
      {children}
    </AtendimentoContext.Provider>
  );
};
