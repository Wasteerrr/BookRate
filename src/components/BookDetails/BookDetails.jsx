import React, {useState, useEffect} from 'react';
import { useParams } from 'react-router-dom';
import Loading from "../Loader/Loader";
import coverImg from "../../images/cover_not_found.jpg"
import "./BookDetails.css";
import { FaArrowLeft } from "react-icons/fa";
import { useNavigate } from 'react-router-dom';

const URL = "https://openlibrary.org/works/";

const BookDetails = () => {
  const { id } = useParams(); 
  const [loading, setLoading] = useState(false);
  const [book, setBook] = useState(null);
  const navigate = useNavigate();

useEffect(() => {
  setLoading(true);
  async function getBookDetails() {
    try{

      console.log(id);
      const response = await fetch(`${URL}${id}.json`);
      const data = await response.json();
      if(data){
        const {description, title, covers, subject_places, subject_times, subjects} = data;
        const newBook = {
          description: description ? description : "Nie znaleziono opisu",
          title: title,
          cover_img: covers ? `https://covers.openlibrary.org/b/id/${covers[0]}-L.jpg` : coverImg,
          subject_places: subject_places ? subject_places.join(", ") : "Nie znaleziono miejsc tematycznych",
          subject_times: subject_times ? subject_times.join(", ") : "Nie znaleziono okresu tematycznego",
          subjects: subjects ? subjects.join(", ") : "Nie znaleziono tematów"

        };
        setBook(newBook);
      } else {
        setBook(null);
      }
      setLoading(false);
    } catch(error) {
      console.log(error);
      setLoading(false);
    }
    
  }
  getBookDetails();
}, [id]);

 
if(loading) return <Loading />;

  return (
    <section className='book-details'>
      <div className='container'>
        <button type='button' className='flex flex-c back-btn' onClick={() => navigate("/book")}>
          <FaArrowLeft size = {22} />
          <span className='fs-18 fw-6'>Wróć</span>
        </button>

      <div className='book-details-content grid' >
        <div className='book-details-img'>
          <img src = {book?.cover_img} alt = "okładka" />
        </div>

        <div className='book-details-info'>
          <div className='book-details-item title'>
            <span className='fw-6 fs-24'>{book?.title}</span>
          </div>
          
          <div className='book-details-item description'>
            <span>{book?.description}</span>
          </div>

          <div className='book-details-item'>
            <span className='fw-6'>Miejsca tematyczne: </span>
            <span className='text-italic'>{book?.subject_places}</span>
          </div>

          <div className='book-details-item'>
            <span className='fw-6'>Okres tematyczny: </span>
            <span className='text-italic'>{book?.subject_times}</span>
          </div>

          <div className='book-details-item'>
            <span className='fw-6'>Tematy: </span>
            <span>{book?.subjects}</span>
          </div>


        </div>
      </div>

      </div>
    </section>
  )
}

export default BookDetails

