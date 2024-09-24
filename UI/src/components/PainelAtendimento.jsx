import React, { useContext } from 'react';
import { AtendimentoContext } from '../context/AtendimentoContext';
import { Typography } from '@mui/material';

const PainelAtendimento = () => {
  const { atendendo } = useContext(AtendimentoContext);

  return (
    <div>
      <Typography variant="h5">Paciente em Atendimento</Typography>
      {atendendo ? <Typography>{atendendo.nome}</Typography> : <Typography>Nenhum paciente chamado.</Typography>}
    </div>
  );
};

export default PainelAtendimento;
