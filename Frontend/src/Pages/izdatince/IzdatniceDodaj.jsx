import { Button, Col, Container, Form, Row } from 'react-bootstrap';
import { Link, useNavigate } from 'react-router-dom';
import Service from '../../services/IzdatnicaService';
import { RoutesNames } from '../../constants';


export default function IzdatniceDodaj() {
  const navigate = useNavigate();


  async function dodaj(e) {
    const odgovor = await Service.dodaj(e);
    if (odgovor.ok) {
      navigate(RoutesNames.IZDATNICE_PREGLED);
    } else {
      alert(odgovor.poruka.errors);
    }
  }

  function handleSubmit(e) {
    e.preventDefault();

    const podaci = new FormData(e.target);


    dodajPolaznik({
      brojIzdatnice: podaci.get('brojizdatnice'),
      datump: podaci.get('datum'),
      osobaSifra: 1, //nije gotovo
      skladistarSifra: 1, //nije gotovo
      napomena: podaci.get('napomena')
    });
  }

  return (
    <Container className='mt-4'>
      <Form onSubmit={handleSubmit}>
        <Form.Group className='mb-3' controlId='brojIzdatnice'>
          <Form.Label>Naziv</Form.Label>
          <Form.Control
            type='text'
            name='brojIzdatnice'
            placeholder='brojIzdatnice'
            maxLength={255}
            required
          />
        </Form.Group>

        <Form.Group className='mb-3' controlId='datum'>
          <Form.Label>Datum</Form.Label>
          <Form.Control
            type='date'
            name='datum'
          />
        </Form.Group>

        <Form.Group className='mb-3' controlId='vrijeme'>
          <Form.Label>Vrijeme</Form.Label>
          <Form.Control
            type='time'
            name='vrijeme'
          />
        </Form.Group>

       

        <Row>
          <Col>
            <Link className='btn btn-danger gumb' to={RoutesNames.IZDATNICE_PREGLED}>
              Odustani
            </Link>
          </Col>
          <Col>
            <Button variant='primary' className='gumb' type='submit'>
              Dodaj Polaznika
            </Button>
          </Col>
        </Row>
      </Form>
    </Container>
  );
}
