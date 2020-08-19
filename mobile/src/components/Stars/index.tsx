import React from 'react';

import * as S from './styles';

import StarIn from '../../assets/StarIn.png';
import StarOut from '../../assets/StarOut.png';

interface ITest {
  stars: number;
}

const CardRecipes: React.FC<ITest> = ({ stars }) => {
  const interationStars = [1, 2, 3, 4, 5];

  return (
    <S.Container>
      {interationStars.map((star) =>
        star <= stars ? <S.Img source={StarIn} /> : <S.Img source={StarOut} />,
      )}
    </S.Container>
  );
};

export default React.memo(CardRecipes);
