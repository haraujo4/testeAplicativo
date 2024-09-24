import React, { useContext, useState } from 'react';
import { AtendimentoContext } from '../context/AtendimentoContext';
import { TextField, Button, MenuItem, Select, FormControl, InputLabel, Grid, Box } from '@mui/material';
import { toast } from 'react-toastify';

const PacienteForm = () => {
  const { addPaciente, updatePaciente,fetchPacienteByEmail } = useContext(AtendimentoContext);
  const[id, setId] = useState('');
  const [nome, setNome] = useState('');
  const [telefone, setTelefone] = useState('');
  const [sexo, setSexo] = useState('M');
  const [email, setEmail] = useState('');
  const [isEditing, setIsEditing] = useState(false);

  const handleSubmit = (e) => {
    e.preventDefault();
    const paciente = { nome, telefone, sexo, email };

    if (isEditing) {
      const data = {
        id: id,
        nome: paciente.nome,
        telefone: paciente.telefone,
        sexo: paciente.sexo,
        email: paciente.email
      }
      console.log(data);
      updatePaciente(data);
      toast.success('Paciente atualizado com sucesso!');
    } else {
      addPaciente(paciente);
      toast.success('Paciente cadastrado com sucesso!');
    }
    resetForm();
  };

  const handleEmailBlur = async () => {
    if (email) {
      try {
        const paciente = await fetchPacienteByEmail(email);
        if (paciente) {
          console.log('Paciente encontrado:', paciente);
          setId(paciente.id);
          setNome(paciente.nome || '');
          setTelefone(paciente.telefone || '');
          setSexo(paciente.sexo || 'M');
          setIsEditing(true);
        } else {
          setIsEditing(false);
        }
      } catch (error) {
        toast.error('Erro ao buscar paciente. Verifique o e-mail e tente novamente.');
      }
    }
  };

  const handleEmailChange = (e) => {
    setEmail(e.target.value);
    setIsEditing(false);
  };

  const resetForm = () => {
    setNome('');
    setTelefone('');
    setSexo('M');
    setEmail('');
    setIsEditing(false);
  };

  return (
    <Box component="form" onSubmit={handleSubmit} sx={{ maxWidth: 400, margin: '0 auto' }}>
      <Grid container spacing={2}>
        <Grid item xs={12}>
          <TextField
            label="Email"
            value={email}
            onChange={handleEmailChange} 
            onBlur={handleEmailBlur} 
            required
            fullWidth
          />
        </Grid>
        <Grid item xs={12}>
          <TextField
            label="Nome"
            value={nome}
            onChange={(e) => setNome(e.target.value)}
            required
            fullWidth
          />
        </Grid>
        <Grid item xs={12}>
          <TextField
            label="Telefone"
            value={telefone}
            onChange={(e) => setTelefone(e.target.value)}
            required
            fullWidth
          />
        </Grid>
        <Grid item xs={12}>
          <FormControl fullWidth required>
            <InputLabel>Sexo</InputLabel>
            <Select
              value={sexo}
              onChange={(e) => setSexo(e.target.value)}
            >
              <MenuItem value="M">Masculino</MenuItem>
              <MenuItem value="F">Feminino</MenuItem>
              <MenuItem value="O">Outros</MenuItem>
            </Select>
          </FormControl>
        </Grid>
        <Grid item xs={12}>
          <Button type="submit" variant="contained" color="primary" fullWidth>
            {isEditing ? 'Atualizar Paciente' : 'Cadastrar Paciente'}
          </Button>
        </Grid>
      </Grid>
    </Box>
  );
};

export default PacienteForm;
