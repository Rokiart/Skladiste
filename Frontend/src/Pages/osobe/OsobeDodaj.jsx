import { Button, Col, Container, Form, Row } from "react-bootstrap";
import { Link, useNavigate,  } from "react-router-dom";
import { RoutesNames } from "../../constants";
import OsobaService from "../../services/OsobaService";
import { useState } from "react";





export default function OsobeDodaj() {
    const navigate = useNavigate();
    const [errors, setErrors] = useState({});

    async function dodajOsobu(osoba){
        const odgovor = await OsobaService.dodaj(osoba);
        if(odgovor.ok){
          navigate(RoutesNames.OSOBE_PREGLED);
        }else{
          console.log(odgovor);
          alert(odgovor.poruka.errors);
        }
    }

    function handleSubmit(e){
        e.preventDefault();
        const podaci = new FormData(e.target);
        const form = e.target;

        if (!form.checkValidity()) {
          setErrors({
              ime: form['ime'].validationMessage,
              prezime: form['prezime'].validationMessage,
              brojTelefona: form['brojTelefona'].validationMessage,
              email: form['email'].validationMessage
          });
          return;
      }

      setErrors({}); // Resetiranje prikaza grešaka
      

        dodajOsobu({
          ime: podaci.get('ime'),
          prezime: podaci.get('prezime'),
          brojTelefona: podaci.get('brojTelefona'),
          email: podaci.get('email')

        });
         
    }

    return(
        <Container className="nt-4">
            <Form onSubmit={handleSubmit}>
        <Form.Group className='mb-3' controlId='ime'>
          <Form.Label>Ime</Form.Label>
          <Form.Control
            type='text'
            name='ime'
            placeholder='Ime'
            maxLength={255}
            required
          />
        </Form.Group>

        <Form.Group className='mb-3' controlId='prezime'>
          <Form.Label>Prezime</Form.Label>
          <Form.Control
            type='text'
            name='prezime'
            placeholder='Prezime'
            maxLength={255}
            required
          />
        </Form.Group>

        <Form.Group className='mb-3' controlId='Broj telefona'>
          <Form.Label>brojTelefona</Form.Label>
          <Form.Control
            type='text'
            name='Broj Telefona'
            placeholder='Broj Telefona'
            maxLength={20}
          />
        </Form.Group>

        <Form.Group className='mb-3' controlId='email'>
          <Form.Label>Email</Form.Label>
          <Form.Control
            type='email'
            name='email'
            placeholder='Email'
            maxLength={100}
          />
        </Form.Group>
    
        <Row>
          <Col>
            <Link className='btn btn-danger gumb' to={RoutesNames.OSOBE_PREGLED}>
              Odustani
            </Link>
          </Col>
          <Col>
            <Button variant='primary' className='gumb' type='submit'>
              Dodaj Osobu
            </Button>
          </Col>
        </Row>
      </Form>
        </Container>
      
    );


}