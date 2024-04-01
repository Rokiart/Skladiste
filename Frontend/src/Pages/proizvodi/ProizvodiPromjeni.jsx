import { useEffect, useState } from 'react';
import { Button, Col, Container, Form, Row } from 'react-bootstrap';
import { Link, useNavigate, useParams } from 'react-router-dom';
import ProizvodService from '../../services/ProizvodService';
import { RoutesNames } from '../../constants';
import useError from '../../hooks/useError';
import InputText from '../../Components/InputText';
import Akcije from '../../Components/Akcije';



export default function ProizvodiPromjeni() {
  const [proizvod, setProizvod] = useState({});

  const routeParams = useParams();
  const navigate = useNavigate();
  const { prikaziError } = useError();


  async function dohvatiProizvod() {

    const odgovor = await ProizvodService
      .getBySifra(routeParams.sifra)
      if(!odgovor.ok){
        prikaziError(odgovor.podaci);
        return;
      }
      setProizvod(odgovor.podaci);

  }

  useEffect(() => {
    dohvatiProizvod();
  }, []);

  async function promjeniProizvod(proizvod) {
    const odgovor = await ProizvodService.promjeni(routeParams.sifra, proizvod);

    if (odgovor.ok) {
      navigate(RoutesNames.PROIZVODI_PREGLED);
      return;
    }
    prikaziError(odgovor.podaci);
  }

  function handleSubmit(e) {
    e.preventDefault();

    const podaci = new FormData(e.target);
    promjeniProizvod({
      naziv: podaci.get('naziv'),
      sifraProizvoda: podaci.get('sifraProizvoda'),
      mjernaJedinica: podaci.get('mjernaJedinica')
     
    });
  }

  return (
    <Container className='mt-4'>
      <Form onSubmit={handleSubmit}>
        <InputText atribut='Naziv' vrijednost={proizvod.naziv} />
        <InputText atribut='sifraProizvoda' vrijednost={proizvod.sifraProizvoda} />
        <InputText atribut='mjernaJedinica' vrijednost={proizvodk.mjernaJedinica} />
       
        <Akcije odustani={RoutesNames.PROIZVODI_PREGLED} akcija='Promjeni proizvod' /> 
      </Form>
    </Container>
  );
}
